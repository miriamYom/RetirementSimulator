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

    return (
        <>
            {/* <MDBBtn onClick={toggleShow}>Vertically centered modal</MDBBtn> */}

            <MDBModal className='login-modal' tabIndex='-1' show={centredModal} setShow={setCentredModal}>
                <MDBModalDialog centered>
                    <MDBModalContent>
                        {/* <MDBModalHeader>

                        </MDBModalHeader> */}
                        <MDBModalBody className='login-body'>
                            <MDBBtn className='btn-close' color='none' onClick={toggleShow}>X</MDBBtn>
                            <img className='login-img' src={img1}></img>
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
                                onClick={async () => {
                                    let res = await axios.post(`https://localhost:7049/RentiermentSimulator/Login?email=${email}`, password)
                                    if (res.status === 0) {
                                        setResult(res);
                                        console.log(res + "jjjjjjj");
                                    }
                                    else {
                                        console.log("hhhhhhhhhhhhh");
                                        navigate("PensionType");
                                    }
                                    // .then(response => response.json())
                                    // .then(navigate("PensionType"))
                                    // .catch(error=>{
                                    //     alert("youe login is uncorrect");
                                    //     console.error(error);})
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