import { useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import React from 'react';
import { useLocation } from 'react-router-dom';

function Vacation() {

    const location = useLocation();
    const data = location.state.data;

    const objectValues = Object.values(data);
    return (
        <div>
            <div>
                {objectValues.map((value, index) => (
                    <p key={index}>{value}</p>
                ))}
            </div>
            <p>Name: {data.name}</p>
            {/* <p>Age: {data.age}</p> */}
        </div>
    );
}
export default Vacation;