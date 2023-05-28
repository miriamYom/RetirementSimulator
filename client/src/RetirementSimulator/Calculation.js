
import { useEffect } from "react";
import { useLocation } from 'react-router-dom';
import axios from 'axios';

function Calculation() {
    const location = useLocation();

    useEffect(() => {
        let employeeDetails = location.state.data;
        const pensionType = employeeDetails.pensionType;
        delete employeeDetails.pensionType;
        axios.post(`https://localhost:7049/RentiermentSimulator/GetPensionCalculates?pensionType=${pensionType}`,
        employeeDetails )
          .then(data => console.log(data))
            .catch(error =>
                console.error('There was an error!\n', error))
    } );

return (
    <>

    </>
);
}
export default Calculation;