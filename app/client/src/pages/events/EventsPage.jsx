import React, { useEffect, useState } from 'react'
import { useFetching } from '../../components/hooks/useFetching'
import { MainEventTable } from '../../components/UI/tables/mainEvents/mainEventTable'
import { Loader } from '../../components/UI/loader/Loader'
import { ErrorPanel } from '../../components/UI/error/ErrorPanel'
import classes from './EventsPage.module.css'
import PayEventTable from '../../components/UI/tables/payEvents/payEventTable'
export const EventsPage = () => {
    const [responseError, setError] = useState('')
    const [mainEvents, setMainEvents] = useState([])

    const [MainList, isMainLoading, error] = useFetching(async () => {
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

    useEffect(() => {
        MainList()
    }, [])

    return (
        <div className={`grid place-items-center gap-4 grid-cols-1 ${classes.myPage}`}>
            {error && <ErrorPanel error={error} />}
            {responseError && <ErrorPanel error={responseError} />}

            <h1>Список событий</h1>

            {isMainLoading ?
                <Loader />
                :
                <MainEventTable events={mainEvents} errorFunc={setError} />
            }

            <PayEventTable events={[]}/>
            
        </div>
    )
}