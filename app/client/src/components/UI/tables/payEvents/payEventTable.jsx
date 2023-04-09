import React from "react";
import MyButton from '../../button/MyButton'
import { useFetching } from "../../../hooks/useFetching";


export const PayEventTable= ({events})=>{
    const [DeleteEvent, isDeleteLoading, deleteError] = useFetching(async (event_id) => {

    })
    const [UpdateEvent, isUpdateLoading, updateError] = useFetching(async (event_id) => {
        
    })

    
    return (
        <div>
            <h1>Таблица оплата</h1>
            <table>
            <thead>
                    <tr>
                        <th className="bg-blue-100 border text-left px-8 py-4">Дата</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">название бота</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">Значение</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">ссылка на бота</th>
                    </tr>
                </thead>
                <tbody>
                    {events.map((event) => (
                        <tr key={event.event_id}>
                            <td class="border px-8 py-4">{event.date}</td>
                            <td class="border px-8 py-4">{event.op_title}</td>
                            <td class="border px-8 py-4">{event.value}</td>
                            <td class="border px-8 py-4">{event.link}</td>
                            <td className="grid grid-cols-1 grid-rows-2">
                                <MyButton 
                                    value={event.event_id} 

                                    children={"Редактировать"}/>
                                <MyButton 
                                    value={event.event_id} 
                                    onClick={(e) => null()}
                                    children={"Удалить"}/>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>

        </div>

    );
    
}
export default PayEventTable;