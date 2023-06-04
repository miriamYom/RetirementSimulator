import { AllInbox } from '@mui/icons-material';
import axios from 'axios';
import { useState } from 'react';
import { useRef } from 'react';

export default function GetAllUsers() {

    const allUsers = useRef();
    // allUsers.current = {};

    const [flag, setflag] = useState(false);
    function getAll() {
        setflag(true);
        axios.get('https://localhost:7049/RentiermentSimulator/GetAll')
            .then((response) => {

                allUsers.current = response.data;

            });
    }


    return (
        <>

            <button /*disabled={flag}*/ onClick={getAll}>קבל פרטי כל המנויים</button>
            <table>
                <tr>
                    <th>שם</th>
                    <th>תפקיד</th>
                    <th>כתובת מייל</th>
                    <th>סיסמה</th>
                    <th>טלפון</th>
                    <th>תוקף מנוי</th>
                </tr>
            </table>
            {/* {allUsers.current.map((item, index) => (
                    <tr key={index}>
                        <td>{item.name}</td>
                        <td>{item.role}</td>
                        <td>{item.email}</td>
                        <td>{item.password}</td>
                        <td>{item.phoneNumber}</td>
                        <td>{item.subscriptionPeriodDate}</td>
                    </tr>
                ))} */}


            
                {Array.isArray(allUsers.current) ? (
                    allUsers.current.map((item, index) => (
                        <tr key={index}>
                            <td> {item.name}</td>
                            <td>{item.role}</td>
                            <td> {item.email}</td>
                            <td>{item.password}</td>
                            <td>{item.phoneNumber}</td>
                            <td> {item.subscriptionPeriodDate}</td>
                        </tr>
                    ))
                ) : (
                    <p>לא נמצאו משתמשים</p>
                )}
            





        </>
    );
}

