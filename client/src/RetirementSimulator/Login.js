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
import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup'
import * as yup from "yup";
import { userLogin } from "../redux/actions/userAction";
import { useSelector, useDispatch } from "react-redux";

function Login() {
    const dispatch = useDispatch();
    let user = useSelector((state) => state.userReducer);

    const navigate = useNavigate();
    const [centredModal, setCentredModal] = useState(false);
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const toggleShow = () => setCentredModal(!centredModal);

    useEffect(() => {
        console.log("useEffect");
        setCentredModal(!centredModal);
    }, [])

    const schema = yup.object().shape({
        email: yup.string().email("כתובת מייל לא תקינה").required("נא הזן.י כתובת מייל"),
        password: yup
            .string().required("נא הזן.י סיסמא")
        // כל הולידציות האלו צריכות להיות בחירת סיסמה
        // .min(8, 'סיסמה חייבת להכיל 8 תוים')
        // .matches(/[0-9]/, 'Password requires a number')
        // .matches(/[a-z]/, 'Password requires a lowercase letter')
        // .matches(/[A-Z]/, 'Password requires an uppercase letter')
        // .matches(/[^\w]/, 'Password requires a symbol'),
    });

    const { register, handleSubmit, formState: { errors } } = useForm({
        resolver: yupResolver(schema),
    });

    const navigetToCurrentPage = () => {
        user.role == "Admin" || user.role == "admin" ?
            navigate("Admun") :
            navigate("PensioType");
    }

    const onSubmitHandler = () => {
        // event.preventDefault();
        let axiosConfig = {
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': "application/json; charset=utf-8" //== "application/json"
            }
        };
        axios.post(`http://localhost:5170/RentiermentSimulator/Login?email=${email}`,
            password)//, axiosConfig)
            .then(response => {
                console.log("response", response);
                if (response.status === 200) {
                    dispatch(userLogin(response.json()));
                    navigetToCurrentPage();
                }
                else {

                }
            })
            .catch(error => {
                alert("youe login is uncorrect");
                console.log(error.response);
            })
    }

    return (
        <>
            <MDBModal className='login-modal' tabIndex='-1' show={centredModal} staticBackdrop={Login} /*setShow={setCentredModal}*/>
                <MDBModalDialog centered>
                    <MDBModalContent>
                        <MDBModalBody className='login-body' >
                            <img className='login-img' src={img1}></img>
                            <form onSubmit={handleSubmit(onSubmitHandler)}>
                                <input className='login-input mail-icom' placeholder='כתובת מייל' type="email"
                                    onChange={(e) => setEmail(e.target.value)}
                                    {...register('email')}>
                                </input>
                                <p style={{ "color": "red" }}>{errors.email?.message}</p>
                                <input className='login-input lock-icom' placeholder='סיסמא' type='password'
                                    onChange={(e) => setPassword(e.target.value)}
                                    {...register('password')}>
                                </input>
                                <p style={{ "color": "red" }}>{errors.password?.message}</p>
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