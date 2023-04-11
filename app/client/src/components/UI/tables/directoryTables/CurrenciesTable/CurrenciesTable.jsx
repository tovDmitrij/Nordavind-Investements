import React from "react";
import MyButton from "../../../button/MyButton";

const CurrenciesTable = ({Data, sample}) => {
    return(
        <div>
            <h1>Currencies table</h1>
        <table>
            <thead>
                <tr>
                    <th>Title </th>
                    <th>Short title </th>
                </tr>
            </thead>
            <tbody>
                {Data.map((row) => ( 
                    <tr>
                        <td>{row.Title} </td>
                        <td>{row.Value} </td>
                    </tr>
                ))}
            </tbody>
        </table>
        <MyButton children={'Добавить валюту'}/>
        </div>
    )
}
export default CurrenciesTable;