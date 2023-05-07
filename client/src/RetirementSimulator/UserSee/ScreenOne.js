import { useState } from "react";
import { useNavigate } from "react-router-dom";
import AccrualPension from "./AccrualPension";
import BudgetPensin from "./BudgetPension";
import { BrowserRouter, Routes, Route } from 'react-router-dom';

function ScreenOne() {
    const navigate = useNavigate();

    const [isBudgetPension, setIsBudget] = useState(false);
    const [isCollectiveAgrementOnly, setIsCollectiveAgreementOnly] = useState(true);
    return (
        <>
            <button className="btn btn-outline-primary" >פנסיה צוברת</button>
            <button className="btn btn-outline-primary" onClick={() => {
                setIsBudget(true);
            }}>פנסיה תקציבית</button>
            <br></br>
            <br></br>
            {/* {isLogged === 0 ? (<Button title="Go to Login" onPress={() => navigation.navigate('Login')} > </Button>) : (<Button title="Stuff" onPress={() => navigation.navigate('DoStuff')} > </Button>)} */}
            {isBudgetPension === true ? (<button className="btn btn-outline-primary">הסכם קיבוצי</button>) : (null)}
            {isBudgetPension === true ? (<button className="btn btn-outline-primary" onClick={() => {
                setIsCollectiveAgreementOnly(false);
            }}> הסכם קיבוצי ושכר בכירים</button>) : (null)}


            <button onClick={() => {isBudgetPension === true && isCollectiveAgrementOnly === true? navigate(`/BudgetPensin`) : isBudgetPension === true? navigate(`/BudgetPensionForSeniorSalary`) : navigate(`/AccrualPension`)}}>הבא</button>
        </>
    )
}
export default ScreenOne;