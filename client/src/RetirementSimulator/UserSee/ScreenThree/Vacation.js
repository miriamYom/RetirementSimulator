// import { useParams } from "react-router-dom";

import { useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";

function Vacation(){

    const navigate = useNavigate();

    const {aaa} = useParams()



    // const {regi} = useParams();
    // const reg = props.reg;
    // console.log("registerrr === ", reg)

    return(


        <>
        <h1>Vacation</h1>
        <h1>{aaa}</h1>
        </>
    )
}
export default Vacation;