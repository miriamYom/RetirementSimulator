import './Header.css';
import logo from "../img/לבן לוגו מיכל לוי (1) 2.png";
import phoneIcon from "../img/phone.png";
import personIcon1 from "../img/person (1).png";
import personIcon2 from "../img/person (2).png";
function Header() {

    return (
        <div className='header'>
            <div className="rec79"></div>

            <div className="frame39">
                <a className="click-to-home-web" href=''>
                    מעבר לדף הבית
                </a>
            </div>
            <div className="group-289328">
                <p className="welcom">היי { }</p>
                <div className='group-welcom'>
                    <img className='personIcon1' src={personIcon1}></img>
                    <img className='personIcon2' src={personIcon2}></img>
                </div>
            </div>
            <div className="group-289327">
                <div className='group'>
                    <img className="vector-phone" src={phoneIcon}></img>
                </div>
                <p className="contact-us"> צור קשר </p>
            </div>
            <img className="logo-header" src={logo}></img>
            <div className="line11"></div>
        </div>
    );
}
export default Header;