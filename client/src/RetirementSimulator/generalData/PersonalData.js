import "./PersonalData.css";

export default function PersonalData() {

    return (
        <div className="wrepper">
            <div className="grid-item">
                {/* <p>PersonalData</p> */}
                <p className="item-title">שם העובד</p>
                <input className="item" name="name" /*{...register('name')}*/ placeholder="שם העובד"></input>
            </div>
            <div className="grid-item">
                <p className="item-title">תעודת זהות</p>
                <input className="item" name="id" /*{...register('id')}*/ placeholder=" תעודת זהות "></input>
            </div>
            <div className="grid-item">
                <p className="item-title">תאריך לידה</p>
                <input className="item" name="birthDate" /*{...register('birthDate')}*/ type="date"></input>
            </div>
            <div className="grid-item">
                <p className="item-title">תאריך תחילת עבודה</p>
                <input className="item" name="startWorkDate" /*{...register('startWorkDate')}*/ type="date"></input>
            </div>
            <div className="grid-item">
                < p className="item-title">תאריך פרישה צפוי</ p>
                <input className="item" name="retirementDate" /*{...register('retirementDate')}*/ type="date"></input>
            </div>
            <div className="grid-item">
                < p className="grid-item">סוג הפרישה</ p>
                <select className="item" name="reason" /*{...register("reason")} onChange={Reason}*/ >
                    <option value="retirementAge">גיל פרישה</option>
                    <option value="resignation">התפטרות</option>
                    <option value="dismissal">פיטורין</option>
                    <option value="retirementForHealthReasons">סיבה רפואית</option>
                    <option value="death">מוות</option>
                </select>
            </div>
            <div className="grid-item">
                < p className="grid-item">חלף הודעה מוקדמת</ p>
                <select className="item" name="advanceNotice" /*{...register("advanceNotice")}*/>
                    <option value="notEligible">לא זכאי</option>
                    <option value="month">חודש</option>
                    <option value="twoMonths">חודשיים</option>
                    <option value="treeMonths">שלושה חודשים</option>
                </select>
            </div>
            <div className="grid-item">
                {/*is marreid / not */}
                < p className="grid-item">מצב משפחתי</ p>
                <select className="item" name="advanceNotice" /*{...register("advanceNotice")}*/>
                    <option value="notEligible">לא זכאי</option>
                    <option value="month">חודש</option>
                    <option value="twoMonths">חודשיים</option>
                    <option value="treeMonths">שלושה חודשים</option>
                </select>
            </div>
        </div >
    );
}