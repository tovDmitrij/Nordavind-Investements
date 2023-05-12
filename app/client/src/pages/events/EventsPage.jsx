import React, { useEffect, useState, useContext } from 'react'
import { useFetching } from '../../components/hooks/useFetching'
import { useNavigate } from "react-router-dom";
import AuthContext from "../../components/context/authContext";
import Loader from '../../components/UI/loaders/Loader'
import ErrorPanel from '../../components/UI/panels/ErrorPanel'
import APIService from "../../API/APIService";
import MainEventTable from '../../components/UI/tables/eventTables/mainEvents/MainEventTable'
import PayEventTable from '../../components/UI/tables/eventTables/payEvents/PayEventTable'
import FlipEventTable from '../../components/UI/tables/eventTables/flipEvents/FlipEventTable';
import SellEventTable from '../../components/UI/tables/eventTables/sellEvents/SellEventsTable';
import styles from './EventsPage.module.css'


const EventsPage = () => {
    const navigate = useNavigate()
    const { isAuth, setIsAuth } = useContext(AuthContext)

    const [responseError, setError] = useState('')
    const [mainEvents, setMainEvents] = useState([])
    const [payEvents,setPayEvent]=useState([])
    const [flipevents,setFlipEvents]= useState([]);
    const [sellEvents,setSellEvents]= useState([]);


    const [MainList, isMainLoading] = useFetching(async () => {
        APIService.GetMainEventsList().then(response => {
            if (response.ok) {
                response.json().then((events) => { setMainEvents(events.events) })
            }
            else if (response.status === 401) {
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else {
                response.json().then((events) => { setError(events.status) })
            }
        }).catch(err => { setError(err.status) })

    })

    const [PayList, isPayLoading ] = useFetching(async () => {
        APIService.GetPayEventsList().then(response => {
            if (response.ok) {
                response.json().then((events) => { setPayEvent(events.events) })
            }
            else if (response.status === 401) {
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else {
                response.json().then((events) => { setError(events.status) })
            }
        }).catch(err => { setError(err.status) })

    })

    const [FlipList, isFlipLoading ] = useFetching( async () => {
        APIService.GetFlipEventsList().then(response => {
            if (response.ok) {
                response.json().then((events) => { setFlipEvents(events.events) })
            }
            else if (response.status === 401) {
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else {
                response.json().then((events) => { setError(events.status) })
            }
        }).catch(err => { setError(err.status) })
    })

    const [SellList, isSellLoading ] = useFetching(async () => {
        APIService.GetSellEventsList().then(response => {
            if (response.ok) {
                response.json().then((events) => { setSellEvents(events.events) })
            }
            else if (response.status === 401) {
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else {
                response.json().then((events) => { setError(events.status) })
            }
        }).catch(err => { setError(err.status) })

    })

    useEffect(() => {
        MainList()
        PayList()
        FlipList()
        SellList()
    }, [])

    return (
        <div className={`grid place-self-center place-items-center gap-4 grid-cols-1 grid-rows-1 ${styles.myPage}`}>
            <h1 className="text-3xl font-bold">События</h1>
            {responseError && <ErrorPanel error={responseError} />}
            <div className="grid gap-5 grid-cols-2">
                {isMainLoading  ? <Loader /> : <MainEventTable events={mainEvents} errorFunc={setError} /> }          
                {isFlipLoading  ? <Loader /> : <FlipEventTable events={flipevents} errorFunc={setError} /> }
                {isPayLoading   ? <Loader /> : <PayEventTable events={payEvents}  errorFunc={setError}/> }             
                {isSellLoading  ? <Loader /> : <SellEventTable events={sellEvents}  errorFunc={setError} /> }
            </div>
        </div>
    )
}


export default EventsPage