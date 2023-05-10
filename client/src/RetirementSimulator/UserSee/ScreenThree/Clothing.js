import { useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup'
import * as yup from "yup";

function Clothing() {

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

const { register, handleSubmit, formState: {errors} } = useForm({
    resolver: yupResolver(schema),
});

    let months =
        <>
            <option value="January">ינואר</option>
            <option value="February">פברואר</option>
            <option value="March">מרץ</option>
            <option value="April">אפריל</option>
            <option value="May">מאי</option>
            <option value="June">יוני</option>
            <option value="July">יולי</option>
            <option value="August">אוגוסט</option>
            <option value="September">ספטמבר</option>
            <option value="October">אוקטובר</option>
            <option value="November">נובמבר</option>
            <option value="December">דצמבר</option>
        </>

    const [isClothingForAudienceMembers, setIsClothingForAudienceMembers] = useState(false);
    const [isMonthlyClothingPayment, setIsMonthlyClothingPayment] = useState(false);
  
    const clothingForAudienceMembers = e => {
        setIsClothingForAudienceMembers(e.target.value);
    }

    const monthlyClothingPayment = e => {
        setIsMonthlyClothingPayment(e.target.value);
    }

    const threeLevel = e => {
        setIsThreeLevel(e.target.value);
    }

    const currentYear = e => {
        setIsCurrentYear(e.target.value);
    }


    return (
        <>
            <form onSubmit={handleSubmit(onSubmit)}>
            <br></br><br></br><br></br><br></br><br></br><br></br><br></br>
                <center>
                    
                    <h1>ביגוד</h1>
                    <h4>זכאות העובד לביגוד</h4>
                    <input type="radio" value="false" name="isClothingForAudienceMembers" {...register('isClothingForAudienceMembers')} onChange={clothingForAudienceMembers} /> ביגוד למקבלי קהל
                    <input type="radio" value="true" name="isClothingForAudienceMembers" {...register('isClothingForAudienceMembers')} onChange={clothingForAudienceMembers} /> ביגוד לפועלים

                    {isClothingForAudienceMembers === "true" ?
                        (<>
                            <br></br>
                            <h4>אופן תשלום הביגוד</h4>
                            <input type="radio" value="false" name="isMonthlyClothingPayment" {...register('isMonthlyClothingPayment')} onChange={monthlyClothingPayment} /> חודשי
                            <input type="radio" value="true" name="isMonthlyClothingPayment" {...register('isMonthlyClothingPayment')} onChange={monthlyClothingPayment} /> שנתי
                            <h4>רמת הביגוד</h4>
                            <input type="radio" value="false" name="IsThreeLevel" {...register('IsThreeLevel')} onChange={threeLevel} /> רמה 3
                            <input type="radio" value="true" name="IsThreeLevel" {...register('IsThreeLevel')} onChange={threeLevel} /> רמה 4
                        </>) : null}
                    {isMonthlyClothingPayment === "false" ?
                        (<>
                            <h4>חודש תשלום הביגוד</h4>
                            <select name="monthOfClothingPayment" {...register("monthOfClothingPayment")}>
                                {months}
                            </select>
                        </>) : null}

                    {isClothingForAudienceMembers === "true" ?
                        (<>
                            <h4>השנה עבורה משולם הביגוד</h4>
                            <input type="radio" value="true" name="IsCurrentYear" {...register('IsCurrentYear')} onChange={currentYear} /> שנה קנדרית קודמת
                            <input type="radio" value="false" name="IsCurrentYear" {...register('IsCurrentYear')} onChange={currentYear} /> שנה נוכחית
                        </>) : null}

                    
                </center>
                <input type="submit"></input>
            </form>
           
        </>
    )
}
export default Clothing;