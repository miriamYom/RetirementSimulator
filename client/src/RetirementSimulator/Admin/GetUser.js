import { yupResolver } from '@hookform/resolvers/yup';
import axios from 'axios';
import React from 'react';
import { useForm } from 'react-hook-form';
import * as yup from 'yup';
import { useState } from 'react';

function GetUser() {
    let [user, setUser] = useState({});

    const schema = yup.object().shape({
        name: yup.string().default(""),
        role: yup.string().default(""),
        email: yup.string().email('Invalid email').required('Email is required'),
        phoneNumber: yup.string().default(""),
        password: yup.string().default(""),
        subscriptionPeriodDate: yup.date().default(() => new Date())
    });

    const { register, handleSubmit, formState: { errors }, reset, getValues } = useForm({
        resolver: yupResolver(schema),
    });

    const onSubmit = (data) => {
        console.log(user);
        axios.post('http://localhost:5170/RentiermentSimulator/GetDetails', data ,)
            .then(response => {
                setUser(response.data);
                console.log(user);
            })
            .then(console.log("user", user))
            .catch(error => {console.log(error);
                alert("נראה שקרתה תקלה. 🧐")});
    };

    return (
        <>
            {Object.keys(user).length !== 0 ?
                <>
                    <p>name:  {user.name}</p>
                    <p>password:  {user.password}</p>
                    <p>phone:  {user.phoneNumber}</p>
                    <p>role:  {user.role}</p>
                    <p>email:  {user.email}</p>
                </> :
                <form onSubmit={handleSubmit(onSubmit)}>
                    <label>כתובת מייל:</label>
                    <input {...register("email")} placeholder="email" type="email" ></input>
                    <p style={{ "color": "red" }}>{errors.email?.message}</p>
                    <button type="submit">Submit</button>
                </form>
            }
        </>
    );
}
export default GetUser;