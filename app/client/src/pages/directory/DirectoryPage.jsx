import React, {useState, useEffect, useContext} from "react";
import CurrenciesTable from "../../components/UI/tables/directoryTables/currenciesTable/CurrenciesTable";
import TradeBotsTable from "../../components/UI/tables/directoryTables/tradeBotsTable/TradeBotsTable";
import ConditionsTable from "../../components/UI/tables/directoryTables/conditionsTable/ConditionsTable";
import AccountTypesTable from "../../components/UI/tables/directoryTables/accountTypesTable/AccountTypesTable";
import PieChart from "../../components/UI/diagram/PieChart";
import { useFetching } from "../../components/hooks/useFetching";
import APIService from "../../API/APIService";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../../components/context/authContext";
import { Loader } from "../../components/UI/loader/Loader";


const DirectoryPage = () =>{
    const navigate = useNavigate()
    const {isAuth, setIsAuth} = useContext(AuthContext)
    const [responseError, setError] = useState('')

    const [Currenciesdata, setCurrenciesdata] = useState([]);
    const [TradeBotsdata, setTradeBotsdata] = useState([]);
    const [AccountTypesdata, setAccountTypesdata] = useState([]);
    const [Conditionsdata, setConditionsdata] = useState([]);    


    const [GetCurrencies, isCurrenciesLoading] = useFetching(async () => {
        APIService.GetCurrenciesList().then(response => {
            if (response.ok){
                response.json().then((data) => {
                    setCurrenciesdata(data.data)
                    setError('')
                })
            }
            else if (response.status === 401){
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else{
                response.json().then((data) => {
                    setError(data.status)
                    console.log(data.status)
                })
            }
        })
    })

    /** ... */


    useEffect (() => {
        GetCurrencies()
        /** ... */
    }, [])


    return(
        <div className="grid gap-4 grid-cols-1 grid-rows-4">
            {responseError}

            {isCurrenciesLoading ? <Loader/> : <CurrenciesTable Data={Currenciesdata}/>}
            <AccountTypesTable Data={AccountTypesdata}/>
            <TradeBotsTable Data={TradeBotsdata}/>
            <ConditionsTable Data={Conditionsdata}/>
            <PieChart />
        </div>
    )
}


export default DirectoryPage;