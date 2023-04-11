import React, { useEffect, useState } from "react";
import { useFetching } from "../../../../hooks/useFetching";
import MyButton from "../../../button/MyButton";
import MyInput from "../../../input/MyInput";
import MySelect from "../../../select/MySelect";
import { Loader } from "../../../loader/Loader";


export const FlipEventForm = () => {
    const [responseError, setError] = useState('')

    const [fundType, setFundType] = useState(0)
    const [accountX, setAccountX] = useState(0)
    const [accountY, setAccountY] = useState(0)
    const [value, setValue] = useState(0)
    const [date, setDate] = useState(new Date())

    const [accounts, setAccounts] = useState([])
    const [funds, setFunds] = useState([])
  
    const [GetAccounts, isAccountsLoading, accountsError] = useFetching(async () => {
        setAccounts([
            {

            },
            {

            }
        ])
    })
    const [GetFunds, isFundsLoading, fundsError] = useFetching(async () => {
        setFunds([
            {

            },
            {

            }
        ])
    })

    const comfirmEvent = (e) => {
        e.preventDefault();
        
    };

    useEffect(() => {
        GetAccounts();
        GetFunds();
    }, [])
  
    return (
        <form className="grid place-items-center gap-4 grid-cols-1 grid-rows-5">
            {isAccountsLoading ?
                <Loader />
            :
            (
                <div className="grid place-items-center gap-4 grid-cols-1 grid-rows-2">
                    <div>
                        <label>Счёт X</label>
                        <MySelect
                            callback={setAccountX}
                            items={accounts}/>
                    </div>

                    <div>
                        <label>Счёт Y</label>
                        <MySelect
                            callback={setAccountY}
                            items={accounts}/>
                    </div>
                </div>
            )}

            {isFundsLoading ?
                <Loader />
            :
            (
                <div className="grid place-items-center gap-4 grid-cols-1 grid-rows-2">
                    <label>Тип средств</label>
                    <MySelect
                        callback={setFundType}
                        items={funds}/>
                </div>
            )}

            <div>
                <label>Сумма</label>
                <MyInput
                    type="number"
                    onChange={(e) => setValue(e.target.value)}
                    placeholder='Введите сумму'/>
            </div>

            <div>
                <label>Дата</label>
                <MyInput
                    type="date"
                    onChange={(e) => setDate(e.target.value)}
                    placeholder='Введите дату'/>
            </div>

            <MyButton 
                onClick={comfirmEvent}
                children={"Подтвердить"}/>
        </form>
    );
}