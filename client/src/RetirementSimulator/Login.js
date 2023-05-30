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

    return (
        <>
            {/* <MDBBtn onClick={toggleShow}>Vertically centered modal</MDBBtn> */}

            <MDBModal tabIndex='-1' show={centredModal} setShow={setCentredModal}>
                <MDBModalDialog centered>
                    <MDBModalContent>
                        <MDBModalHeader>

                        </MDBModalHeader>
                        <MDBModalBody className='login-body'>
                            <MDBBtn className='btn-close' color='none' onClick={toggleShow}>X</MDBBtn>
                            <img src={img1}></img>
                            <input className='login-input mail-icom' placeholder='מייל' type="email"
                                onChange={(e) => setEmail(e.target.value)} required={true}>
                            </input>
                            <input className='login-input lock-icom' placeholder='סיסמא' type='text'
                                onChange={(e) => setPassword(e.target.value)} required={true}>
                            </input>
                            <a href='https://www.google.com/search?q=%D7%AA%D7%A8%D7%92%D7%95%D7%9E%D7%95%D7%9F&rlz=1C1SQJL_iwIL974IL974&oq=&aqs=chrome.2.35i39i362l6j46i39i362j35i39i362.490596j0j7&sourceid=chrome&ie=UTF-8'>שכחת סיסמא?</a>
                        </MDBModalBody>
                        <MDBModalFooter>
                            <MDBBtn className='login-connect'
                                onClick={() => {
                                    const requestOptions = {
                                        method: 'POST',
                                        headers: { 'Content-Type': 'application/json' },
                                        body: `"${password}"`
                                    };
                                    fetch(`https://localhost:7049/RentiermentSimulator/Login?email=${email}`, requestOptions)
                                        .then(response => response.json())
                                        .then(data => console.log(data))
                                        .then(navigate("PensionType"))
                                        .catch(error => {
                                            alert({ errorMessage: error.toString() });
                                            console.error('There was an error!\n', error);
                                        });
                                }}
                            >התחברות</MDBBtn>
                        </MDBModalFooter>
                    </MDBModalContent>
                </MDBModalDialog>
            </MDBModal>
        </>
    );
}
export default Login;