
import { useEffect, useRef, useState } from "react";
import { useLocation } from 'react-router-dom';
import axios from 'axios';

function Calculation() {
    const result = useRef();
    console.log(result)
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
            .then((response) => result = response.json())
            .then(console.log(result))
            .catch(error => console.error('There was an error!\n', error))
    }, []);

    result.current = {
        "name": "someone",
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
    };

    return (
        <>
            <table >
                <thead>
                    <tr>
                        <th>תוצאה:</th>
                        <th>חישוב:</th>
                    </tr>
                </thead>
                {Object.keys(result.current).map((key, i) => (
                    <tr>
                        <td>{result.current[key]}</td>
                        <td>{key}</td>
                    </tr>
                ))}
            </table>
        </>
    );
}
export default Calculation;
