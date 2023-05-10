import React from "react";
import MyButton from "../../../button/MyButton";

const TradeBotsTable = ({Data, sample}) =>{
      return(
        <div>
            <h1>Trade bots table</h1>
        <table>
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Description</th>
                </tr>
            </thead>
            <tbody>
                {Data.map((row) => (
                    <tr>
                        <td>{row.title}</td>
                        <td>{row.description}</td>
                    </tr>
                ))}
            </tbody>
        </table>
        <MyButton children={'Добавить тип бота'}/>
        </div>

      )
}
export default TradeBotsTable;