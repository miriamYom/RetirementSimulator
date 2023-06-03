import { AllInbox } from '@mui/icons-material';
import axios from 'axios';
import { useState } from 'react';
import { useRef } from 'react';

export default function GetAllUsers() {

    const allUsers = useRef();
    allUsers.current = {};
    // allUsers.current = [
    //     { "name": 'Baruch Shraga', "role": 'Yeshiva bocher', "email": 'm025328642@gmail.com', "phoneNumber": '0548546224', "password": '6666' },
    //     { "name": 'Bibi', "role": 'Prime Minister', "email": 'bibist@bib', "phoneNumber": '11111111', "password": '12345' }
    // ];
    let [flag, setflag] = useState(false);
    function getAll() {
        setflag(true);
        axios.get('https://localhost:7049/RentiermentSimulator/GetAll')
            .then((data) => {
                console.log(data);
                console.log(JSON.stringify(allUsers.current) === '{}');
                allUsers.current = data.data;
                console.log(allUsers.current[0]);
                console.log(allUsers);
                console.log(JSON.stringify(allUsers.current) === '{}');
            });
    }

    return (
        <>
            <button disabled={flag} onClick={getAll}>קבל פרטי כל המנויים</button>
            {/* { 
                 JSON.stringify(allUsers.current) === '{}' ?
                    null :*/}
            <table>
                <tr>
                    <th>name</th>
                    <th>role</th>
                    <th>email</th>
                    <th>password</th>
                    <th>phone number</th>
                    <th>subscriptionPeriodDate</th>
                    {/* <th>is sub?</th> */}
                </tr>
                {Object.keys(allUsers.current).map((item, i) => (
                    <tr>
                        <td>{item.name}</td>
                        <td>{item.role}</td>
                        <td>{item.email}</td>
                        <td>{item.password}</td>
                        <td>{item.phoneNumber}</td>
                        <td>{item.subscriptionPeriodDate}</td>
                        {/* <th>{item.subscriptionPeriodDate > new Date()}</th> */}
                    </tr>
                ))}
            </table>
            {/* } */}
        </>
    );
}
