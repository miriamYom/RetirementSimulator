import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

function Api() {
    const navigate = useNavigate();

    const [name, setName] = useState("");
    const [role, setRole] = useState("");
    const [email, setEmail] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [password, setPassword] = useState("");
    const [subscriptionPeriodDate, setSubscriptionPeriodDate] = useState(new Date());

    function getAll() {
        fetch('https://localhost:7049/RentiermentSimulator/GetAll'/*, requestOptions*/)
            .then(response => response.json())
            .then(data => console.log(data));
    }

    function validateForm() {
        //change this
        return true;
    }

    function handleSubmit(event) {
        event.preventDefault();
    }

    function createUser() {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body:JSON.stringify({
                name,role,email,phoneNumber,password,subscriptionPeriodDate
              })
    };
    fetch('https://localhost:7049/RentiermentSimulator/CreateUser', requestOptions)
        .then(response => response.json())
        .then(data => console.log(data))
        .then(navigate('/ScreenOne'))
        .catch(error => {
            alert({ errorMessage: error.toString() });
            console.error('There was an error!\n', error);
        });
}



return (
    <center>
        <button block size="lg" type="submit" onClick={getAll}>
            Get all users
        </button>
        <br></br>
        <br></br>
        <br></br>
        <label>Create new user</label>
        <form onSubmit={handleSubmit}>
            <form size="lg" controlId="email">
                <p>Name</p>
                <input
                    autoFocus
                    type="text"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />
            </form>
            <form size="lg" controlId="email">
                <p>Role</p>
                <input
                    autoFocus
                    type="text"
                    value={role}
                    onChange={(e) => setRole(e.target.value)}
                />
            </form>
            <form size="lg" controlId="email">
                <p>Email</p>
                <input
                    autoFocus
                    type="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
            </form>
            <form size="lg" controlId="email">
                <p>Phone number</p>
                <input
                    autoFocus
                    type="number"
                    value={phoneNumber}
                    onChange={(e) => setPhoneNumber(e.target.value)}
                />
            </form>
            <form size="lg" controlId="password">
                <p>Password</p>
                <input
                    type="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
            </form>
            <form size="lg" controlId="email">
                <p>Subscription period date</p>
                <input
                    autoFocus
                    type="date"
                    value={subscriptionPeriodDate}
                    onChange={(e) => setSubscriptionPeriodDate(e.target.value)}
                />
            </form>
            <br></br>
            <button block size="lg" type="submit" disabled={!validateForm()} onClick={createUser}>
                Create!
            </button>

        </form>
    </center>

);
}
export default Api;