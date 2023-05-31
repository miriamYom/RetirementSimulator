import { useState, useEffect } from 'react';
import {
    MDBBtn,
    MDBModal,
    MDBModalDialog,
    MDBModalContent,
    MDBModalHeader,
    MDBModalTitle,
    MDBModalBody,
    MDBModalFooter,
} from 'mdb-react-ui-kit';
import './style/Login.css';
import img1 from "../img/connect.png";
import { useNavigate } from "react-router-dom";
import axios from 'axios';

function Login() {
    const navigate = useNavigate();
    const [centredModal, setCentredModal] = useState(false);

    const toggleShow = () => setCentredModal(!centredModal);

    useEffect(() => {
        console.log("useEffect");
        setCentredModal(!centredModal);
    }, [])

    let [email, setEmail] = useState("");
    let [password, setPassword] = useState("");
    let [result, setResult] = useState();

    function login() {
        console.log("login=> 😝");
        console.log(email);
        console.log(password);
        const config = { headers: { 'Content-Type': 'application/json' } };
        axios.post(`https://localhost:7049/RentiermentSimulator/Login?email=${email}`,
            { password }, config)
            .then(res => {
                res.status === 200 ?
                    navigate("PensionType") :
                    alert("youe login is uncorrect");
            })
            .catch(error => {
                alert("youe login is uncorrect");
                console.error(error);
            })
    }
    const [name, setName] = useState("");

    const handleSubmit = (event) => {
        event.preventDefault();
        let axiosConfig = {
            headers: {
                'Content-Type': 'application/json;charset=UTF-8',
                "Access-Control-Allow-Origin": "*",
            }
          };
        axios.post(`https://localhost:7049/RentiermentSimulator/Login?email=${email}`,
            password  , axiosConfig)
            .then(res => {
                res.status === 200 ?
                    navigate("PensionType") :
            })
            .catch(error => {
                alert("youe login is uncorrect");
                console.error(error);
            })
    }

    return (
        <>
            <MDBModal className='login-modal' tabIndex='-1' show={centredModal} staticBackdrop={Login} /*setShow={setCentredModal}*/>
                <MDBModalDialog centered>
                    <MDBModalContent>
                        <MDBModalBody className='login-body' >
                            <img className='login-img' src={img1}></img>
                            <form onSubmit={handleSubmit}>
                                <input className='login-input mail-icom' placeholder='מייל' type="email"
                                    onChange={(e) => setEmail(e.target.value)} required="required">
                                </input>
                                <input className='login-input lock-icom' placeholder='סיסמא' type='text'
                                    onChange={(e) => setPassword(e.target.value)} required="required">
                                </input>
                                <br></br>
                                <a href='https://www.google.com/search?q=%D7%AA%D7%A8%D7%92%D7%95%D7%9E%D7%95%D7%9F&rlz=1C1SQJL_iwIL974IL974&oq=&aqs=chrome.2.35i39i362l6j46i39i362j35i39i362.490596j0j7&sourceid=chrome&ie=UTF-8'>שכחת סיסמא?</a>
                                <br></br>
                                <MDBBtn type='submit' className='login-connect' /*onClick={login}*/>התחברות</MDBBtn>
                            </form>
                        </MDBModalBody>
                    </MDBModalContent>
                </MDBModalDialog>
            </MDBModal >
        </>
    );
}
export default Login;