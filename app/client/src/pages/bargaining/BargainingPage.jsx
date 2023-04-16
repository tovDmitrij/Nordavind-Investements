import React, {useState, useEffect} from "react";
import BargainingTable from "../../components/UI/tables/bargainingTable/BargainingTable";


const BargainingPage = () =>{
    const[Bargaindata, setBargaindata] = useState([]);
   
    
    
    
    const GenerateData = () =>{
        setBargaindata([{Time:'fafas',Numbers:'vasgh', Balance:'fhjfd', Percent:'2152'},{Time:'fafas',Numbers:'vasgh', Balance:'fhjfd', Percent:'2152'}])
        
    }
    useEffect (() =>{GenerateData()}, [])
    return(
        <div className="grid gap-4 grid-cols-1 grid-rows-4">
            <BargainingTable Data={Bargaindata}/>
            
           
        </div>
        

    )
}
export default BargainingPage;