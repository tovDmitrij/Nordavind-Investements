import React from "react";
import MyButton from "../../../button/MyButton";

const ConditionsTable = ({Data, sample}) => {
    return(
        <div>
            <h1>Conditions table</h1>
        <table>
            <thead>
                <tr>
                    <th>Title </th>
                    <th>Description </th>
                    <th>Value </th>
                </tr>
            </thead>
            <tbody>
                {Data.map((row)=> (
                     <tr>
                        <td>{row.title} </td>
                        <td>{row.description} </td>
                        <td>{row.value} </td>
                     </tr>
                ))}
            </tbody>
        </table>
        <MyButton children={'Добавить условие распределения'}/>
        </div>
    )
}
export default ConditionsTable;