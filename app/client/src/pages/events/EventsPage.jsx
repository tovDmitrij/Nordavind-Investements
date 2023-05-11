import React, { useEffect, useState, useContext } from 'react'
import { useFetching } from '../../components/hooks/useFetching'
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../../components/context/authContext";
import { Loader } from '../../components/UI/loader/Loader'
import { ErrorPanel } from '../../components/UI/error/ErrorPanel'
import APIService from "../../API/APIService";
import MainEventTable from '../../components/UI/tables/eventTables/mainEvents/mainEventTable'
import PayEventTable from '../../components/UI/tables/eventTables/payEvents/payEventTable'
import FlipEventTable from '../../components/UI/tables/eventTables/flipEvents/flipEventTable';
import SellEventTable from '../../components/UI/tables/eventTables/sellEvents/sellEventsTable';
import styles from './EventsPage.module.css'


export const EventsPage = () => {
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
                response.json().then((events) => {
                    setMainEvents(events.events)
                    setError('')
                })
            }
            else if (response.status === 401) {
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else {
                response.json().then((events) => {
                    setError(events.status)
                    console.log(events.status)
                })
            }
        })

         
    })

    const [PayList, isPayLoading ] = useFetching(async () => {
        APIService.GetPayEventsList().then(response => {
            if (response.ok) {
                response.json().then((events) => {
                    setPayEvent(events.events)
                    setError('')
                })
            }
            else if (response.status === 401) {
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else {
                response.json().then((events) => {
                    setError(events.status)
                    console.log(events.status)
                })
            }
        })

    })

    const [FlipList, isFlipLoading ] = useFetching( async () => {
        APIService.GetFlipEventsList().then(response => {
            if (response.ok) {
                response.json().then((events) => {
                    setFlipEvents(events.events)
                    setError('')
                })
            }
            else if (response.status === 401) {
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else {
                response.json().then((events) => {
                    setError(events.status)
                    console.log(events.status)
                })
            }
        })
    })

    const [SellList, isSellLoading ] = useFetching(async () => {
        APIService.GetSellEventsList().then(response => {
            if (response.ok) {
                response.json().then((events) => {
                    setSellEvents(events.events)
                    setError('')
                })
            }
            else if (response.status === 401) {
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else {
                response.json().then((events) => {
                    setError(events.status)
                    console.log(events.status)
                })
            }
        })

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