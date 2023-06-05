import { yupResolver } from '@hookform/resolvers/yup';
import axios from 'axios';
import React from 'react';
import { useForm } from 'react-hook-form';
import * as yup from 'yup';

function DeleteUser() {
    const schema = yup.object().shape({
        name: yup.string(),//.required(),
        role: yup.string(),//.required(),
        email: yup.string().email(),//.required('Email is required'),'Invalid email'
        phoneNumber: yup.number(),//.required()
        subscriptionPeriodDate: yup.date()//.required()
    })

    const { register, handleSubmit, formState: { errors }, reset, getValues } = useForm({
        resolver: yupResolver(schema),
    });

    const onSubmit = (data) => {
        console.log(data)
        axios.delete("https://localhost:7049/RentiermentSimulator/DeleteUser", { data })
            .then(response => console.log(response))
    }



    return (
        <>
            <label>delete user</label>
            <form onSubmit={handleSubmit(onSubmit)}>

                <label>כתובת מייל:</label>
                <input {...register("email")} placeholder="email" type="email" ></input>
                {/* <p style={{ "color": "red" }}>{errors.email?.message}</p> */}

                <label>טלפון:</label>
                <input {...register("phoneNumber")} type="text" ></input>
                {/* <p style={{ "color": "red" }}>{errors.phoneNumber?.message}</p> */}

                <label>תוקף מנוי:</label>
                <input {...register("subscriptionPeriodDate")} type="date" ></input>
                {/* <p style={{ "color": "red" }}>{errors.subscriptionPeriodDate?.message}</p> */}

                <button type="submit">Submit</button>
            </form>

        </>
    );
}
export default DeleteUser;