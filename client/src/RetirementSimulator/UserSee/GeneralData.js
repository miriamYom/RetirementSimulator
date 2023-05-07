import { useForm } from "react-hook-form"

function GeneralData() {
    const { register, handleSubmit } = useForm();

    return (

        <>
            <center>
                <input name="name" {...register('name')} placeholder="שם העובד"></input>
                <br></br>
                <input name="id" {...register('id')} placeholder="תעודת זהות"></input>
                <br></br>
                <input name="birthDate" {...register('birthDate')} placeholder="תאריך לידה"></input>
                <br></br>
                <input name="startWorkDate" {...register('startWorkDate')} placeholder="תאריך תחילת עבודה" type="date"></input>
                <br></br>
                <input name="retirementDate" {...register('retirementDate')} placeholder="תאריך פרישה צפוי" type="date"></input>
                <br></br>
                <label>סוג הפרישה</label>
                <select name="reason" {...register("reason")}>
                    <option value="retirementAge">גיל פרישה</option>
                    <option value="resignation">התפטרות</option>
                    <option value="dismissal">פיטורין</option>
                    <option value="retirementForHealthReasons">סיבה רפואית</option>
                    <option value="death">מוות</option>
                </select>
                <br></br>
            </center>
        </>
    )
}
export default GeneralData;