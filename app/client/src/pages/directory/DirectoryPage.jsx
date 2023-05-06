import React, {useState, useEffect} from "react";
import CurrenciesTable from "../../components/UI/tables/directory/currencies/CurrenciesTable";
import TradeBotsTable from "../../components/UI/tables/directory/tradeBots/TradeBotsTable";
import ConditionsTable from "../../components/UI/tables/directory/conditions/ConditionsTable";
import AccountTypesTable from "../../components/UI/tables/directory/accountTypes/AccountTypesTable";
import useFetching from "../../components/hooks/useFetching";
import FetchLoader from "../../components/UI/loaders/fetch/FetchLoader";
import ErrorPanel from "../../components/UI/panels/error/ErrorPanel";


const DirectoryPage = () =>{
    const [currencies, setCurrencies] = useState([]);
    const [tradeBots, setTradeBots] = useState([]);
    const [accountTypes, setAccountTypes] = useState([]);
    const [conditions, setConditions] = useState([]);
    const [responseError, setError] = useState('')
    
    const [GetCurrencies, isCurrLoading, currError] = useFetching(async () => {
        await fetch(`https://localhost:7047/api/Directory/Сurrencies/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + sessionStorage.getItem('token')
            }            
        }).then(response => {
            if(response.ok){
                response.json().then((data) => {
                    setCurrencies(data.data)
                })
            }
        }).catch(err => { setError(err.status) })
    })

    const [GetAccountTypes, isAccLoading, accError] = useFetching(async () => {
        await fetch(`https://localhost:7047/api/Directory/AccountTypes/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + sessionStorage.getItem('token')
            }            
        }).then(response => {
            if(response.ok){
                response.json().then((data) => {
                    setAccountTypes(data.data)
                })
            }
        }).catch(err => { setError(err.status) })
    })

    const [GetBotTypes, isBotLoading, botError] = useFetching(async () => {
        await fetch(`https://localhost:7047/api/Directory/BotTypes/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + sessionStorage.getItem('token')
            }            
        }).then(response => {
            if(response.ok){
                response.json().then((data) => {
                    setTradeBots(data.data)
                })
            }
        }).catch(err => { setError(err.status) })
    })

    const [GetConditions, isCondLoading, condError] = useFetching(async () => {
        await fetch(`https://localhost:7047/api/Directory/Conditions/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + sessionStorage.getItem('token')
            }            
        }).then(response => {
            if(response.ok){
                response.json().then((data) => {
                    setConditions(data.data)
                })
            }
        }).catch(err => { setError(err.status) })
    })

    useEffect (() => {
        GetCurrencies()
        GetAccountTypes()
        GetBotTypes()
        GetConditions()
    }, [])

    return(
        <div className="grid place-items-center gap-4 grid-cols-1">
            {responseError && <ErrorPanel error={responseError} />}
            {currError && <ErrorPanel error={currError} />}
            {accError && <ErrorPanel error={accError} />}
            {botError && <ErrorPanel error={botError} />}
            {condError && <ErrorPanel error={condError} />}

            <b className="text-5xl">Справочник</b>

            {isCurrLoading ? <FetchLoader /> : <CurrenciesTable Data={currencies} />} 
            {isAccLoading ? <FetchLoader /> : <AccountTypesTable Data={accountTypes} />}
            {isBotLoading ? <FetchLoader /> : <TradeBotsTable Data={tradeBots}/>}
            {isCondLoading ? <FetchLoader /> : <ConditionsTable Data={conditions}/>}
        </div>
    )
}


export default DirectoryPage;