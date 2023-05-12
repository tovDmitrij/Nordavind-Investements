import React from "react";
import MyButton from "../../../buttons/MyButton";


/**
 * Таблица курсов валют
 * @param {*} data - список валют
 */
const CurrenciesTable = ({data}) => {
    return(
        <div className="flex flex-col gap-3 place-items-center">
            <h1 className="text-2xl font-bold">Список курсов валют</h1>
            <table className="border-collapse border">
                <thead>
                    <tr>
                        <th className="border p-3">Наименование</th>
                        <th className="border p-3">Краткое наименование</th>
                        <th className="border p-3">Действия</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map((row) => ( 
                        <tr key={row.title}>
                            <td className="border p-3">{row.title} </td>
                            <td className="border p-3">{row.shortTitle} </td>
                            <td className="border p-3 grid place-items-center">
                                <MyButton children={'Редактировать'}/>
                                <MyButton children={'Удалить'}/>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <MyButton children={'Добавить валюту'}/>
        </div>
    )
}


export default CurrenciesTable;