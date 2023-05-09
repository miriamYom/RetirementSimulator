import './Header.css';
import logo from "../img/לבן לוגו מיכל לוי (1) 2.png"
function Header() {

    return (
        <div className='header'>
            <div className="rec79">
                <img className="logo-header" src={logo}></img>
                <div className="frame39">
                    <div className="click-to-home-page">
                        מעבר לדף הבית
                    </div>
                </div>
                <div className="group-289327">
                    <img className="vector-phone" src="src\img\phone.png"></img>
                    <p className="contact-us"> צור קשר </p>
                </div>
                <div className="line11"></div>
                <div>
                    {/* <img>אין איקון נורמלי...</img> */}
                    <p className="welcom">היי {}</p>
                </div>
            </div>
        </div>
    );
}
export default Header;