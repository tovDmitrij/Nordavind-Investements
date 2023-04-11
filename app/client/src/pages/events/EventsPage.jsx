import React, { useEffect, useState } from 'react'
import useFetching from '../../components/hooks/useFetching'
import FetchLoader from "../../components/UI/loaders/fetch/FetchLoader";
import ErrorPanel from "../../components/UI/panels/error/ErrorPanel";
import classes from './EventsPage.module.css'
import MainEventTable from '../../components/UI/tables/events/main/MainEventTable'
import PayEventTable from '../../components/UI/tables/events/pay/PayEventTable'
import FlipEventTable from '../../components/UI/tables/events/flip/FlipEvents';
import SellEventsTable from '../../components/UI/tables/events/sell/SellEventsTable';


const EventsPage = () => {
    const [responseError, setError] = useState('')
    const [mainEvents, setMainEvents] = useState([])
    const [payEvents, setPayEvent]=useState([])
    const [flipEvents, setFlipEvents]= useState([]);
    const [sellEvents, setSellEvents]= useState([]);

    const [MainList, isMainLoading, mainError] = useFetching(async () => {
        await fetch(`https://localhost:7047/api/Event/MainEvents/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + sessionStorage.getItem('token')
            }            
        }).then(response => {
            if(response.ok){
                response.json().then((data) => {
                    setMainEvents(data.data)
                })
            }
        }).catch(err => { setError(err.status) })  
    })

    const [PayList, isPayLoading, payError] = useFetching(async () => {
        await fetch(`https://localhost:7047/api/Event/PayEvents/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + sessionStorage.getItem('token')
            }            
        }).then(response => {
            if(response.ok){
                response.json().then((data) => {
                    setPayEvent(data.data)
                })
            }
        }).catch(err => { setError(err.status) })
    })

    const [FlipList, isFlipLoading, flipError] = useFetching( async () => {
        await fetch(`https://localhost:7047/api/Event/FlipEvents/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + sessionStorage.getItem('token')
            }            
        }).then(response => {
            if(response.ok){
                response.json().then((data) => {
                    setFlipEvents(data.data)
                })
            }
        }).catch(err => { setError(err.status) })
    })

    const [SellList, isSellLoading, sellError] = useFetching(async () => {
        await fetch(`https://localhost:7047/api/Event/SellEvents/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + sessionStorage.getItem('token')
            }            
        }).then(response => {
            if(response.ok){
                response.json().then((data) => {
                    setSellEvents(data.data)
                })
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
        <div className={`grid place-items-center gap-4 grid-cols-1 ${classes.myPage}`}>
            {mainError && <ErrorPanel error={mainError} />}
            {payError && <ErrorPanel error={payError} />}
            {flipError && <ErrorPanel error={flipError} />}
            {sellError && <ErrorPanel error={sellError} />}
            {responseError && <ErrorPanel error={responseError} />}

            <b className="text-5xl">События</b>

            {isMainLoading ? <FetchLoader /> : <MainEventTable events={mainEvents} errorFunc={setError} /> }
            {isPayLoading? <FetchLoader /> : <PayEventTable events={payEvents}  errorFunc={setError}/> }   
            {isFlipLoading? <FetchLoader /> : <FlipEventTable events={flipEvents}  errorFunc={setError} /> }   
            {isSellLoading? <FetchLoader /> : <SellEventsTable events={sellEvents}  errorFunc={setError} /> }
        </div>
    )
}


export default EventsPage