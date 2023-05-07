import { useState } from "react";
import {useForm} from "react-hook-form"

function GeneralData(){
    const [name, setName] = useState("");
    const { register, handleSubmit } = useForm();

    return(

        <>
        <label>שם העובד</label>
        </>
    )
}
export default GeneralData;