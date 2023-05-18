import "./ScreenOne.css";
import Sequence from "./Sequence";
import PreviousNext from "./PreviousNext";

function ScreenTwo(){

    return(
        <>
        <Sequence page="2"></Sequence>
            <div class="card bg-light mb-3">
                <div class="card-header">נתונים כליליים</div>
                <div class="card-body">

                </div>
            </div>
            <PreviousNext next="Vacation" previous="ScreenOne"></PreviousNext>
        </>
    )
}
export default ScreenTwo;