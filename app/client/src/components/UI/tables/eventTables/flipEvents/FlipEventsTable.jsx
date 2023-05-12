import React from "react";
import MyButton from '../../../buttons/MyButton'


/**
 * Таблица с событиями на переброс
 * @param {*} events - список событий 
 */
const FlipEventTable = ({events}) => {
    return (
        <div className="flex flex-col gap-3 place-items-center">
            <h1 className="text-2xl font-bold">Список событий на переброс</h1>
            <table className="border-collapse border">
                <thead>
                    <tr>
                        <th className="border p-3" rowSpan={2}>Дата</th>
                        <th className="border p-3" rowSpan={2}>Инвестор</th>
                        <th className="border p-3" colSpan={2}>Тип средств</th>
                        <th className="border p-3" rowSpan={2}>A/C X</th>
                        <th className="border p-3" rowSpan={2}>A/C Y</th>
                        <th className="border p-3" rowSpan={2}>Действия</th>
                    </tr>
                    <tr>
                        <th className="border p-3">Проценты</th>
                        <th className="border p-3">Тело</th>
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
                                    <td className="border p-3">{event.date}</td>
                                    <td className="border p-3">{event.investor}</td>
                                    <td className="border p-3">{event.value}</td>
                                    <td className="border p-3">{event.value}</td>
                                    <td className="border p-3">{event.accountFrom}</td>
                                    <td className="border p-3">{event.accountTo}</td>
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


export default FlipEventTable