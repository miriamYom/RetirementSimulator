// import { useParams } from "react-router-dom";

function Vacation(props){

    // const {regi} = useParams();
    const reg = props.reg;
    console.log("registerrr === ", reg)

    return(


        <>
        <h1>Vacation</h1>
        <h1>{reg}</h1>
        </>
    )
}
export default Vacation;