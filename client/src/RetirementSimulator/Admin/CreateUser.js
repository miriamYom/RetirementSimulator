import { yupResolver } from '@hookform/resolvers/yup';
import axios from 'axios';
import React from 'react';
import { useForm } from 'react-hook-form';
import * as yup from 'yup';



function CreateUser() {
    // const [name, setName] = useState("");
    // const [role, setRole] = useState("");
    // const [email, setEmail] = useState("");
    // const [phoneNumber, setPhoneNumber] = useState("");
    // const [password, setPassword] = useState("");
    // const [subscriptionPeriodDate, setSubscriptionPeriodDate] = useState(new Date());


    const schema = yup.object().shape({
        name: yup.string().required(),
        role: yup.string().required(),
        email: yup.string().email('Invalid email').required('Email is required'),
        phoneNumber: yup.number().required(),
        // password: yup.string().required('Password is required').min(8, 'סיסמה חייבת להכיל 8 תוים')
        //     .matches(/[0-9]/, 'Password requires a number')
        //     .matches(/[a-z]/, 'Password requires a lowercase letter')
        //     .matches(/[A-Z]/, 'Password requires an uppercase letter')
        //     .matches(/[^\w]/, 'Password requires a symbol'),
        subscriptionPeriodDate: yup.date().required()

    });

    // function validateForm() {
    //     //change this
    //     return true;
    // };

    // function handleSubmit(event) {
    //     event.preventDefault();
    //     // createUser();
    // };

    const { register, handleSubmit, formState: { errors }, reset, getValues } = useForm({
        resolver: yupResolver(schema),
    });

    // const onSubmitHandler = (data) => {
    //     console.log(data.data);
    //     axios.post(`https://localhost:7049/RentiermentSimulator/CreateUser`,
    //     {
    //         data
    //     })
    //     .then(data => console.log(data))
    //         .catch(error =>
    //             console.error('There was an error!\n', error));
    // };

    const onSubmit = (data) => {
        console.log(typeof(data) )
        axios.post('https://localhost:7049/RentiermentSimulator/CreateUser', data)
            .then(response => console.log(response.data))
            .catch(error => console.error(error));
    };


    // function createUser() {
    //     axios.post(`https://localhost:7049/RentiermentSimulator/CreateUser`,
    //         {
    //             name,
    //             role,
    //             email,
    //             phoneNumber,
    //             password,
    //             subscriptionPeriodDate
    //         }
    //     )
    //         .then(data => console.log(data))
    //         .catch(error =>
    //             console.error('There was an error!\n', error));
    // };

    return (
        <>
            <label>Create new user</label>
            <form onSubmit={handleSubmit(onSubmit)}>

                <label>שם:</label>
                <input {...register("name")} type="text" />
                <p style={{ "color": "red" }}>{errors.name?.message}</p>

                <label>תפקיד:</label>
                <input {...register("role")} type="text" />
                <p style={{ "color": "red" }}>{errors.role?.message}</p>

                <label>כתובת מייל:</label>
                <input {...register("email")} placeholder="email" type="email" />
                <p style={{ "color": "red" }}>{errors.email?.message}</p>

                <label>טלפון:</label>
                <input {...register("phoneNumber")} type="text" />
                <p style={{ "color": "red" }}>{errors.phoneNumber?.message}</p>

                <label>סיסמה:</label>
                <input {...register("password")} type="password" />
                <p style={{ "color": "red" }}>{errors.password?.message}</p>

                <label>תוקף מנוי:</label>
                <input {...register("subscriptionPeriodDate")} type="date" />
                <p style={{ "color": "red" }}>{errors.subscriptionPeriodDate?.message}</p>

                <button type="submit">Submit</button>
            </form>

        </>
    );
};
export default CreateUser;