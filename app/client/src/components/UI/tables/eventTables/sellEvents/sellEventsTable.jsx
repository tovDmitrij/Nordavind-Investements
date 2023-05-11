import React from "react";
import MyButton from '../../.././button/MyButton'


const SellEventTable= ({events})=>{

    return (
        <div className="flex flex-col gap-3 place-items-center">
            <h1 className="text-2xl font-bold">Список событий на продажу</h1>
            <table>
            <thead>
                    <tr>
                        <th className="border p-3">Дата</th>
                        <th className="border p-3">Сумма</th>
                        <th className="border p-3">Наименование бота</th>
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
                                <td class="border px-8 py-4">{event.date}</td>
                                <td class="border px-8 py-4">{event.value}</td>
                                <td class="border px-8 py-4">{event.botTitle}</td>
                                <td class="border px-8 py-4">{event.link}</td>
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


export default SellEventTable;