import { useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup'
import * as yup from "yup";
import Vacation from "../ScreenThree/Vacation";

function PersonalData() {



    const onSubmit = (data) => {
        console.log(data);
    }


    const schema = yup.object().shape({
        name: yup.string().required(),
        id: yup.string().required(),
        birthDate: yup.date(),//min, max...
        startWorkDate: yup.date(),
        retirementDate: yup.date().required(),
        // reason:  enum
        //isClothingForAudienceMembers: radio button
        // IsThreeLevel: radio
        // monthOfClothingPayment: enum
        // IsCurrentYear: radio
        //IsMonthlyRecoveryPayment: radio
        numberOfDaysOfRecoveryToBePaid: yup.number().integer().min(8).max(13).required(),
        //recoveryPaymentMonth: enum

    });

    const { register, handleSubmit, formState: { errors } , getValues} = useForm({
        resolver: yupResolver(schema),
    });



    const [reason, setReason] = useState('retirementAge');

    const Reason = e => {
        setReason(e.target.value);
    }

    const is_register=()=>{
        // console.log("in personal data" , register.data);
    }


    return (
        <>
            <form onSubmit={handleSubmit(onSubmit)}>
                <br></br><br></br><br></br><br></br><br></br><br></br><br></br>
                <center>
                    <input name="name" {...register('name')} placeholder="שם העובד"></input>
                    <br></br>
                    <input name="id" {...register('id')} placeholder="תעודת זהות"></input>
                    <h4>תאריך לידה</h4>
                    <input name="birthDate" {...register('birthDate')} type="date"></input>
                    <h4>תאריך תחילת עבודה</h4>
                    <input name="startWorkDate" {...register('startWorkDate')} type="date"></input>
                    <h4>תאריך פרישה צפוי</h4>
                    <input name="retirementDate" {...register('retirementDate')} type="date"></input>
                    <h4>סוג הפרישה</h4>
                    <select name="reason" {...register("reason")}
                        onChange={Reason}>
                        <option value="retirementAge">גיל פרישה</option>
                        <option value="resignation">התפטרות</option>
                        <option value="dismissal">פיטורין</option>
                        <option value="retirementForHealthReasons">סיבה רפואית</option>
                        <option value="death">מוות</option>
                    </select>

                    <br></br>
                    {reason === "dismissal" ?
                        (<>
                            <h4>חלף הודעה מוקדמת</h4>
                            <select name="advanceNotice" {...register("advanceNotice")}>
                                <option value="notEligible">לא זכאי</option>
                                <option value="month">חודש</option>
                                <option value="twoMonths">חודשיים</option>
                                <option value="treeMonths">שלושה חודשים</option>
                            </select>
                        </>) : null}
                </center>




                            
                {/* <button onClick={<Vacation reg = {JSON.stringify(getValues())}></Vacation>}></button> */}


                <button onClick={is_register}>update Vacation page</button> 
                <Vacation reg = {JSON.stringify(getValues())}></Vacation>



                {/* מצב משפחתי */}
            </form>

        </>
    )
}
export default PersonalData;