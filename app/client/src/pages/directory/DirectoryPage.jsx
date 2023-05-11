import React, {useState, useEffect, useContext} from "react";
import { useNavigate } from "react-router-dom";
import { useFetching } from "../../components/hooks/useFetching";
import AuthContext from "../../components/context/authContext";
import Loader from "../../components/UI/loaders/Loader";
import ErrorPanel from '../../components/UI/panels/ErrorPanel'
import MyModal from '../../components/UI/modals/MyModal'
import APIService from "../../API/APIService";
import CurrenciesTable from "../../components/UI/tables/directoryTables/currenciesTable/CurrenciesTable";
import TradeBotsTable from "../../components/UI/tables/directoryTables/tradeBotsTable/TradeBotsTable";
import ConditionsTable from "../../components/UI/tables/directoryTables/conditionsTable/ConditionsTable";
import AccountTypesTable from "../../components/UI/tables/directoryTables/accountTypesTable/AccountTypesTable";
import styles from './DirectoryPage.module.css'
import AddDictionaryForm from "../../components/UI/forms/dictionary/add/AddDictionaryForm";
import UpdateDictionaryForm from "../../components/UI/forms/dictionary/update/UpdateDictionaryForm";



/**
 * Страница-справочник со списками типов ботов, валют, схем распределения и т.д.
 */
const DirectoryPage = () =>{
    const navigate = useNavigate()
    const {isAuth, setIsAuth} = useContext(AuthContext)
    const [responseError, setError] = useState('')
    const [modal, setModal] = useState(false);

    const [CurrenciesData, setCurrenciesData] = useState([]);
    const [TradeBotsData, setTradeBotsData] = useState([]);
    const [AccountTypesData, setAccountTypesData] = useState([]);
    const [ConditionsData, setConditionsData] = useState([]);    

    const [GetCurrencies, isCurrenciesLoading] = useFetching(async () => {
        APIService.GetCurrenciesList().then(response => {
            if (response.ok){
                response.json().then((data) => { setCurrenciesData(data.data) })
            }
            else if (response.status === 401){
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else{
                response.json().then((data) => { setError(data.status) })
            }
        }).catch(err => { setError(err.status) })
    })

    const [GetBotTypes, isBotTypesLoading] = useFetching(async () => {
        APIService.GetBotTypesList().then(response => {
            if (response.ok) {
                response.json().then((data) => { setTradeBotsData(data.data) })
            }
            else if (response.status === 401) {
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else {
                response.json().then((data) => { setError(data.status) })
            }
        }).catch(err => { setError(err.status) })
    })

    const [GetConditions, isConditionsLoading] = useFetching(async () => {
        APIService.GetConditionsList().then(response => {
            if (response.ok) {
                response.json().then((data) => { setConditionsData(data.data) })
            }
            else if (response.status === 401) {
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else {
                response.json().then((data) => { setError(data.status) })
            }
        }).catch(err => { setError(err.status) })
    })

    const [GetAccountTypes, isAccountTypesLoading] = useFetching(async () => {
        APIService.GetAccountTypesList().then(response => {
            if (response.ok) {
                response.json().then((data) => { setAccountTypesData(data.data) })
            }
            else if (response.status === 401) {
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else {
                response.json().then((data) => { setError(data.status) })
            }
        }).catch(err => { setError(err.status) })
    })

    useEffect (() => {
        GetCurrencies()
        GetBotTypes()
        GetConditions()
        GetAccountTypes()
    }, [])

    const SomeFunc = () => {
        setModal(false)
    }

    return(
        <div className={`grid place-self-center place-items-center gap-4 grid-cols-1 grid-rows-1 ${styles.myPage}`}>
            <h1 className="text-3xl font-bold">Справочник</h1>

            {responseError && <ErrorPanel error={responseError} />}
            <div className="grid gap-5 grid-cols-2">
                {isCurrenciesLoading    ? <Loader /> : <CurrenciesTable data={CurrenciesData} />}
                {isBotTypesLoading      ? <Loader /> : <TradeBotsTable data={TradeBotsData} />}
                {isConditionsLoading    ? <Loader /> : <ConditionsTable data={ConditionsData} />}
                {isAccountTypesLoading  ? <Loader /> : <AccountTypesTable data={AccountTypesData} />}    
            </div>
        </div>
    )
}


export default DirectoryPage;