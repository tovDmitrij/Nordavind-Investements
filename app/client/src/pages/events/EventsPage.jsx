import React, { useEffect, useState } from 'react'
import { useFetching } from '../../components/hooks/useFetching'
import { Loader } from '../../components/UI/loader/Loader'
import { ErrorPanel } from '../../components/UI/error/ErrorPanel'
import { MainEventTable } from '../../components/UI/tables/eventTables/mainEvents/mainEventTable'
import { PayEventTable } from '../../components/UI/tables/eventTables/payEvents/payEventTable'
import { FlipEventTable } from '../../components/UI/tables/eventTables/flipEvents/flipEventTable';
import { SellEventTable } from '../../components/UI/tables/eventTables/sellEvents/sellEventsTable';
import classes from './EventsPage.module.css'


export const EventsPage = () => {
    const [responseError, setError] = useState('')
    const [mainEvents, setMainEvents] = useState([])
    const [payEvents,setPayEvent]=useState([])
    const [events,setFlipEvents]= useState([]);
    const [sellEvents,setSellEvents]= useState([]);


    const [MainList, isMainLoading, mainError] = useFetching(async () => {
        setMainEvents([{
            event_id: 1,
            date: "2022-01-01",
            investor: "FIO1",
            op_title: "OperTitle1",
            value: 23712,
            account_id: 4
          },
          {
            event_id: 2,
            date: "2022-01-03",
            investor: "FIO2",
            op_title: "OperTitle2",
            value: 21714,
            account_id: 3
          }])

         
    })

    const [PayList, isPayLoading ] = useFetching(async () => {
        setPayEvent([{
            event_id: 1,
            date: "2020-02-15",
            op_title: "OperTitle1",
            value: 23712,
            link: 6
          },
          {
            event_id: 2,
            date: "2021-02-15",
            op_title: "OperTitle2",
            value: 243335,
            link: 5
        
        }])

    })

    const [FlipList, isFlipLoading ] = useFetching( async () => {
        setFlipEvents([
            {

            date: '2023-04-09',
            op_title: 'Funds Transfer',
            value: 1000,
            A_C_X: 123456,
            A_C_Y: 789012,
        },
        {

            date: '2021-02-19',
            op_title: 'Account Deposit',
            value: 100.00,
            A_C_X: 101,
            A_C_Y: 789012,
        },
        {

            date: '2022-01-01',
            op_title: 'Funds Transfer',
            value: 40.00,
            A_C_X: 102,
            A_C_Y: 103,
         }
        ])
    })

    const [SellList, isSellLoading ] = useFetching(async () => {
        setSellEvents([{ 
        }])

    })


    useEffect(() => {
        MainList()
        PayList()
        FlipList()
        SellList()
    }, [])


    return (
        <div className={`grid place-items-center gap-4 grid-cols-1 ${classes.myPage}`}>
            {responseError && <ErrorPanel error={responseError} />}

            <h1>Список событий</h1>

            {mainError && <ErrorPanel error={error} />}
            {isMainLoading ? <Loader /> : <MainEventTable events={mainEvents} errorFunc={setError} /> }
            
            {isFlipLoading ? <Loader /> : <FlipEventTable events={events}  errorFunc={setError} /> }

            {isPayLoading ? <Loader /> : <PayEventTable events={payEvents}  errorFunc={setError}/> }
             
            {isSellLoading ? <Loader /> : <SellEventTable events={sellEvents}  errorFunc={setError} /> }
        </div>
    )
}