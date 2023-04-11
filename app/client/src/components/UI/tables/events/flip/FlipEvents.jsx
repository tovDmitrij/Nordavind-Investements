import React from "react";
import MyButton from '../../../buttons/main/MyButton'


const FlipEventTable = ({events}) => {
    return (
        <div className="grid place-items-center grid-cols-1 grid-rows-2">
            <b>Переброс</b>

            <table className="shadow-lg bg-white">
                <thead>
                    <tr>
                        <th className="bg-blue-100 border text-left px-8 py-4">Дата</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">Тип операции</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">Сумма</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">A/C X</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">A/C Y"</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">Действия</th>
                    </tr>
                </thead>
                <tbody>
                    {events.map((event) => (
                        <tr key={event.event_id}>
                                <td class="border px-8 py-4">{event.date}</td>
                                <td class="border px-8 py-4">{event.op_title}</td>
                                <td class="border px-8 py-4">{event.value}</td>
                                <td class="border px-8 py-4">{event.A_C_X}</td>
                                <td>{event.A_C_Y}</td>
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
}


export default FlipEventTable