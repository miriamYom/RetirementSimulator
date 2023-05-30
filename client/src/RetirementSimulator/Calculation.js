
import { useEffect, useState } from "react";
import { useLocation } from 'react-router-dom';
import axios from 'axios';

function Calculation() {
    const location = useLocation();
    const [result, setResult] = useState({});

    useEffect(() => {
        //let employeeDetails = location.state.data;
        //const pensionType = employeeDetails.pensionType;
        //delete employeeDetails.pensionType;
        const pensionType = "BudgetPension";
        let employeeDetails = {
            "name": "string",
            "id": 0,
            "birthDate": "2023-05-30T10:05:48.071Z",
            "startWorkDate": "2023-05-30T10:05:48.071Z",
            "retirementDate": "2023-05-30T10:05:48.071Z",
            "reason": 0,
            "advanceNotice": 99,
            "isClothingForAudienceMembers": true,
            "isMonthlyClothingPayment": true,
            "isThreeLevel": true,
            "monthOfClothingPayment": 1,
            "isCurrentYear": true,
            "isMonthlyRecoveryPayment": true,
            "numberOfDaysOfRecoveryToBePaid": 0,
            "recoveryPaymentMonth": 1,
            "lastPartTimeJob": 0,
            "partTimeJobCurrentYear": 0,
            "partTimeJobLastYear": 0,
            "salaryDetermines": 0,
            "remainingSickDays": 0,
            "isFullAccrual": true,
            "remainingVacationDaysInRetirement": 0,
            "isFiveBusinessDays": true,
            "isAggregationByParts": true
        }

        axios.post(`https://localhost:7049/RentiermentSimulator/GetPensionCalculates?pensionType=${pensionType}`,
            employeeDetails)
            .then(response => setResult(JSON.parse(JSON.stringify(response.data))))
            .then(console.log(result))
            // .then(console.log(result["advanceNotice"])) // make troubles- return undefind

            .catch(error => console.error('There was an error!\n', error))
    }, []);

    return (

        <>
            <p></p>
        </>
    );
}
export default Calculation;
