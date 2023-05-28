import './style/PreviousNext.css';
import { useNavigate } from "react-router-dom";


// the func get props who set witch page to go
function PreviousNext(props) {

    const navigate = useNavigate();

    return (

        <div className="group-289375">
            {props.next !== "GeneralData" ? (<button className="button1"
                onClick={() => {
                    navigate(-1, { state: { data: props.data } });
                   }}
                >
                הקודם</button>) : (null)}

            <button className="button2" onClick={() => {
                navigate(`/${props.next}`, { state: { data: props.data } });
            }} disabled={!props.enableNext} >
                {props.next === "Calculation" ? "חשב" : "הבא"}
            </button>
        </div>
    );
}
export default PreviousNext;