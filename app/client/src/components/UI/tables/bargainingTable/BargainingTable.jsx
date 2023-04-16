import React from "react";
import './BargainingTable.module.css'

const BargainingTable = ({Data, sample}) => {
    return(
       <div> 
         <table>
            <caption>Таблица торгов</caption>
            <thead>
                <tr>
                <th  rowspan="2"><input type="date" placeholder="Дата/период"/> <input type="date" placeholder="Дата/период"/> </th>
                <th colspan="3"><input type="number" placeholder="Номер счета/все"/>  </th>
                </tr>
                <tr>
                    <th >Closed Trade P/L </th>
                    <th >Previous Ledger Balance </th>
                    <th >Заработанный %</th>
                    
                </tr>
            </thead>
            <tbody>
                {Data.map((row)=> (
                     <tr>
                        <td align="center">{row.Time}</td>
                        <td align="center">{row.Numbers} </td>
                        <td align="center">{row.Balance}</td>
                        <td align="center">{row.Percent}</td>
                     </tr>
    
                ))}
                
            </tbody>
         </table>
       </div>
    )
}
export default BargainingTable;