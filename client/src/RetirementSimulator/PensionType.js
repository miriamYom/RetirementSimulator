import "./style/Card.css";
import "./style/PensionType.css";

import { useState } from "react";
import PreviousNext from "./PreviousNext";
import Sequence from "./Sequence";
import React from 'react';

function PensionType() {
    const [isBudgetPension, setIsBudget] = useState(false);
    const [isCollectiveAgrementOnly, setIsCollectiveAgreementOnly] = useState(true);

    const employeeDetails = {}; //empty object, change to register?

    return (
        <>
            <Sequence page="1"></Sequence>
            <div class="card bg-light mb-3">
                <div class="card-header">סוג פנסיה</div>
                <div class="card-body">
                    <p>איזה סוג פנסיה תרצה לחשב?</p>


                    <button className="btn btn-outline-primary" onClick={() => {
                        setIsBudget(true);
                    }}> פנסיה תקציבית </button>

                    <button name="accrualBtn" className="btn btn-outline-primary" >פנסיה צוברת</button>
                    <br></br>
                    <br></br>
                    {isBudgetPension === true ? (<button className="btn btn-outline-primary">הסכם קיבוצי</button>) : (null)}
                    {isBudgetPension === true ? (<button className="btn btn-outline-primary" onClick={() => {
                        setIsCollectiveAgreementOnly(false);
                    }}> הסכם קיבוצי ושכר בכירים</button>) : (null)}

                    {employeeDetails.isBudgetPension = isBudgetPension}
                    {employeeDetails.isCollectiveAgrement = isCollectiveAgrementOnly}
                </div>
            </div>
             <PreviousNext next="GeneralData" previous="null" data={employeeDetails}></PreviousNext>
        </>
    )
}
export default PensionType;