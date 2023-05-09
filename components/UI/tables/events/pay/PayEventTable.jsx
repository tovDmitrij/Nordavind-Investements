import React from "react";
import MyButton from '../../../buttons/main/MyButton'


const PayEventTable= ({events})=>{
    return (
        <div className="grid place-items-center grid-cols-1 grid-rows-2">
            <b>Оплата</b>

            <table>
                <thead>
                    <tr>
                        <th className="bg-blue-100 border text-left px-8 py-4">Дата</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">название бота</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">Значение</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">ссылка на бота</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">Действия</th>
                    </tr>
                </thead>
                <tbody>
                    {events.map((event) => (
                        <tr key={event.event_id}>
                            <td className="border px-8 py-4">{event.date}</td>
                            <td className="border px-8 py-4">{event.op_title}</td>
                            <td className="border px-8 py-4">{event.value}</td>
                            <td className="border px-8 py-4">{event.link}</td>
                            <td className="grid grid-cols-1 grid-rows-2">
                                <MyButton 
                                    value={event.event_id} 
                                    children={"Редактировать"}/>
                                    
                                <MyButton 
                                    value={event.event_id} 
                                    children={"Удалить"}/>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>

            <MyButton 
                children={"Добавить"}/>
        </div>
    );
};


export default PayEventTable;