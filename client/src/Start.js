import { useNavigate } from "react-router-dom";
export default function Start(){
    const navigate = useNavigate();
    return(
        <button onClick={()=>{navigate('/PensionType');}}>start</button>
    )
}