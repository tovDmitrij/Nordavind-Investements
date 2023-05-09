import React from "react";
import { Pie } from "react-chartjs-2";


const labels = ["Бонусы", "% инвесторов", "% наши", "Наши", "Заемные"];
const data = {
     
  labels: labels,
  datasets: [
    {
      
      backgroundColor: [
        'rgba(235, 130, 132, 1)',
        'rgba(255, 30, 255, 1)',
        'rgba(255, 206, 86, 1)',
        'rgba(75, 192, 192, 1)',
        'rgba(153, 102, 255, 1)'],
      borderColor: "rgb(0,0,0,0.2)",
      data: [63893, 15215, 64226, 198960, 269375],
    },
  ],
};


const PieChart = () => {
    return (
        <div>
            <Pie data={data}/>
        </div>
    );
};


export default PieChart;