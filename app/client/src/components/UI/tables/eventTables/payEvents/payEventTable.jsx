import React from "react";
import MyButton from '../../.././button/MyButton'


/**
 * Таблица с событиями на оплату
 * @param {*} events - список событий
 */
const PayEventTable= ({events})=>{
    return (
        <div className="flex flex-col gap-3 place-items-center">
            <h1 className="text-2xl font-bold">Список событий на оплату</h1>
            <table className="border-collapse border">
                <thead>
                    <tr>
                        <th className="border p-3">Дата</th>
                        <th className="border p-3">Сумма</th>
                        <th className="border p-3">Счёт</th>
                        <th className="border p-3">Действия</th>
                    </tr>
                </thead>
                <tbody>
                    {events.length == 0 ?
                        <tr>
                            <td colSpan={5} class="border px-8 py-4">
                                События отсутствуют
                            </td>
                        </tr>
                        :
                        events.map((event) => (
                            <tr key={event.event_id}>
                                <td className="border p-3">{event.date}</td>
                                <td className="border p-3">{event.value}</td>
                                <td className="border p-3">{event.link}</td>
                                <td className="border p-3 grid place-items-center">
                                    <MyButton children={'Редактировать'}/>
                                    <MyButton children={'Удалить'}/>
                                </td>
                            </tr>
                        ))
                    }
                </tbody>
            </table>
            <MyButton children={"Добавить событие"}/>
        </div>

    );
    
};


export default PayEventTable;