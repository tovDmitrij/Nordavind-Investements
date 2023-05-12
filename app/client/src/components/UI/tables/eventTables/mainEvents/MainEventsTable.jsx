import React from "react";
import MyButton from '../../../buttons/MyButton'


/**
 * Таблица основных событий  
 * @param {*} events - список событий
 */
const MainEventTable = ({events}) => {
    return (
        <div className="flex flex-col gap-3 place-items-center">
            <h1 className="text-2xl font-bold">Список основных событий</h1>
            <table className="border-collapse border">
                <thead>
                    <tr>
                    <th className="border p-3" rowSpan={2}>Дата</th>
                        <th className="border p-3" rowSpan={2}>Инвестор</th>
                        <th className="border p-3" colSpan={3}>Тип средств</th>
                        <th className="border p-3" rowSpan={2}>A/C</th>
                        <th className="border p-3" rowSpan={2}>Действия</th>
                    </tr>
                    <tr>
                        <th className="border p-3">Ввод средств</th>
                        <th className="border p-3">Вывод средств</th>
                        <th className="border p-3">Вывод процентов</th>
                    </tr>
                </thead>
                <tbody>
                    {events.length === 0 ?
                        <tr>
                            <td colSpan={7} class="border px-8 py-4">
                                События отсутствуют
                            </td>
                        </tr>
                        :
                        events.map((event) => (
                            <tr key={event.event_id}>
                                <td class="border px-8 py-4">{event.date}</td>
                                <td class="border px-8 py-4">{event.investor}</td>
                                <td class="border px-8 py-4">{event.op_title}</td>
                                <td class="border px-8 py-4">{event.value}</td>
                                <td class="border px-8 py-4">{event.account_id}</td>
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
}


export default MainEventTable