import axios from 'axios';
import { useEffect, useState } from 'react';

function CreateUser() {
    const [name, setName] = useState("");
    const [role, setRole] = useState("");
    const [email, setEmail] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [password, setPassword] = useState("");
    const [subscriptionPeriodDate, setSubscriptionPeriodDate] = useState(new Date());

    function validateForm() {
        //change this
        return true;
    };

    function handleSubmit(event) {
        event.preventDefault();
        // createUser();
    };

    function createUser() {
        axios.post(`https://localhost:7049/RentiermentSimulator/CreateUser`, 
           { name,
            role,
            email,
            phoneNumber,
            password,
            subscriptionPeriodDate}
        )
            .then(data => console.log(data))
            .catch(error =>
                console.error('There was an error!\n', error));
    };

    return (
        <>
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
                    <input type="tel"
                        // autoFocus
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
        </>
    );
};
export default CreateUser;