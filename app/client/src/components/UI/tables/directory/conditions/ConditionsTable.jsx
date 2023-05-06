import React from "react";
import MyButton from "../../../buttons/main/MyButton";


const ConditionsTable = ({Data, sample}) => {
    return(
        <div className="grid place-items-center">
            <h1>Список условий распределений</h1>

            <table className="shadow-lg bg-white">
                <thead>
                    <tr>
                        <th className="bg-blue-100 border text-left px-8 py-4">Наим.</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">Описание</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">Значение</th>
                    </tr>
                </thead>
                <tbody>
                    {Data.map((row)=> (
                        <tr key={row.id}>
                            <td className="border px-8 py-4">{row.title} </td>
                            <td className="border px-8 py-4">{row.description} </td>
                            <td className="border px-8 py-4">{row.value} </td>
                        </tr>
                    ))}
                </tbody>
            </table>

            <MyButton 
                children={'Добавить условие распределения'}/>
        </div>
    )
}


export default ConditionsTable;