import React, {useState, useEffect} from "react";
import CurrenciesTable from "../../components/UI/tables/directoryTables/CurrenciesTable/CurrenciesTable";
import TradeBotsTable from "../../components/UI/tables/directoryTables/TradeBotsTable/TradeBotsTable";
import ConditionsTable from "../../components/UI/tables/directoryTables/ConditionsTable/ConditionsTable";
import AccountTypesTable from "../../components/UI/tables/directoryTables/AccountTypesTable/AccountTypesTable";
import PieChart from "../../components/UI/diagram/PieChart";


const DirectoryPage = () =>{
    const[Currenciesdata, setCurrenciesdata] = useState([]);
    const[TradeBotsdata, setTradeBotsdata] = useState([]);
    const[AccountTypesdata, setAccountTypesdata] = useState([]);
    const[Conditionsdata, setConditionsdata] = useState([]);
    
    const GenerateData = () =>{
        setCurrenciesdata([{Title:'fafas',Value:'vasgh'},{Title:'gkdld', Value:'fkdooe'}])
        setTradeBotsdata([{Title:'cjgk',Value:'fjkld'},{Title:'gkdfl', Value:'gfdfk'}])
        setAccountTypesdata([{Title:'iqofl',Value:'toytio'},{Title:'qwriot', Value:'cmxxz'}])
        setConditionsdata([{Title:'xznv', Description:'zjgl', Value:'eptpr'},{Title:'xmnv', Description:'topyp', Value:'zgjgkf'}])
        
    }
    useEffect (() =>{GenerateData()}, [])
    return(
        <div className="grid gap-4 grid-cols-1 grid-rows-4">
            <CurrenciesTable Data={Currenciesdata}/>
            <AccountTypesTable Data={AccountTypesdata}/>
            <TradeBotsTable Data={TradeBotsdata}/>
            <ConditionsTable Data={Conditionsdata}/>
           <PieChart />
        </div>
        

    )
}
export default DirectoryPage;