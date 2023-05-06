import React from "react";
import MyButton from '../../.././button/MyButton'
import { useFetching } from "../../../../hooks/useFetching"


/**
 * Таблица основных событий  
 * @param {*} events - список событий
 * @param {*} errorFunc - callback для отправки сообщения об ошибке
 */
export const MainEventTable = ({events, errorFunc}) => {
    const [DeleteEvent, isDeleteLoading, deleteError] = useFetching(async (event_id) => {

    })
    const [UpdateEvent, isUpdateLoading, updateError] = useFetching(async (event_id) => {
        
    })

    return (
        <div className="grid gap-4 place-items-center grid-cols-1 grid-rows-2">
            {isDeleteLoading}
            <h1>Ввод/вывод средств и вывод процентов </h1>
            <table className="shadow-lg bg-white">
                <thead>
                    <tr>
                        <th className="bg-blue-100 border text-left px-8 py-4">Дата</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">Инвестор</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">Тип операции</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">Сумма</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">Номер счёта</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">Действия</th>
                    </tr>
                </thead>
                <tbody>
                    {events.map((event) => (
                        <tr key={event.event_id}>
                            <td class="border px-8 py-4">{event.date}</td>
                            <td class="border px-8 py-4">{event.investor}</td>
                            <td class="border px-8 py-4">{event.op_title}</td>
                            <td class="border px-8 py-4">{event.value}</td>
                            <td class="border px-8 py-4">{event.account_id}</td>
                            <td className="grid grid-cols-1 grid-rows-2">
                                <MyButton 
                                    value={event.event_id} 

                                    children={"Редактировать"}/>
                                <MyButton 
                                    value={event.event_id} 
                                    onClick={(e) => DeleteEvent(e.value)}
                                    children={"Удалить"}/>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <MyButton children={"Добавить"}/>
        </div>
    );
}