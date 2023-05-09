import React from "react";
import MyButton from "../../../buttons/main/MyButton";


const AccountTypesTable = ({Data, sample}) => {
    return(
       <div className="grid place-items-center"> 
            <b>Список типов счетов</b>

            <table className="shadow-lg bg-white">
                <thead>
                    <tr>
                        <th className="bg-blue-100 border text-left px-8 py-4">Наим.</th>
                        <th className="bg-blue-100 border text-left px-8 py-4">Описание</th>
                    </tr>
                </thead>
                <tbody>
                    {Data.map((row)=> (
                        <tr key={row.id}>
                            <td className="border px-8 py-4">{row.title} </td>
                            <td className="border px-8 py-4">{row.description} </td>
                        </tr>
                    ))}
                </tbody>
            </table>

            <MyButton 
                children={'Добавить тип счёта'}/>
       </div>
    )
}


export default AccountTypesTable;