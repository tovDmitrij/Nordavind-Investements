import React from "react";
import MyButton from "../../../button/MyButton";


/**
 * Таблица условий распределения
 * @param {*} data - список условий
 */
const ConditionsTable = ({data}) => {
    return(
        <div className="flex flex-col gap-3 place-items-center">
            <h1 className="text-2xl font-bold">Список условий распределения</h1>
            <table className="border-collapse border">
                <thead>
                    <tr>
                        <th className="border p-3">Наименование</th>
                        <th className="border p-3">Описание</th>
                        <th className="border p-3">Значение</th>
                        <th className="border p-3">Действия</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map((row)=> (
                        <tr key={row.title}>
                            <td className="border p-3">{row.title}</td>
                            <td className="border p-3">{row.description}</td>
                            <td className="border p-3">{row.value}</td>
                            <td className="border p-3 grid place-items-center">
                                <MyButton children={'Редактировать'}/>
                                <MyButton children={'Удалить'}/>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <MyButton children={'Добавить условие распределения'}/>
        </div>
    )
}


export default ConditionsTable;