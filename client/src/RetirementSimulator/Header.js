import './style/Header.css';
import logo from "../img/לבן לוגו מיכל לוי (1) 2.png";
import phoneIcon from "../img/phone.png";
import personIcon from "../img/person.png";
function Header() {

    return (
        <div className='header'>

            <div className="frame39">
                <a className="click-to-home-web" href='https://michallcpa.co.il/'>
                    מעבר לאתר הבית
                </a>
            </div>
            <div className="group-289328">
                <p className="welcome">היי דודי</p>
                <img className='personIcon' src={personIcon}></img>
            </div>
            <div className="group-289327">
                <img className="vector-phone" src={phoneIcon}></img>
                <p className="contact-us">צור קשר</p>
            </div>
            <img className="logo-header" src={logo} onClick={() => { window.location.href = "https://simulator.michallcpa.co.il/HomeComponent" }}></img>
            <div className="line11"></div>
        </div>
    );
}
export default Header;