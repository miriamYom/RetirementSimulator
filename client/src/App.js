// דע כי ה... הוא הנותן... לעשות חיל
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import LoginPage from './RetirementSimulator/LoginPage';
import Api from './RetirementSimulator/Api';
import ScreenOne from './RetirementSimulator/ScreenOne';
import CreateEmployee from './RetirementSimulator/CreateEmployee';


function App() {
  return (
    <div className='App-header'>
     <BrowserRouter>
     {/* <Api></Api> */}
     <CreateEmployee></CreateEmployee>
        {/* <Routes>
        <Route exact path="/" element={<LoginPage></LoginPage>}/>
         <Route exact path="ScreenOne" element={<ScreenOne></ScreenOne>}></Route>
         </Routes> */}
      </BrowserRouter>

     
    </div>
  );
}

export default App;
