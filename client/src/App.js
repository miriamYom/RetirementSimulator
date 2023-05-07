// דע כי ה... הוא הנותן... לעשות חיל
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import LoginPage from './RetirementSimulator/LoginPage';
import Api from './RetirementSimulator/Api';
import ScreenOne from './RetirementSimulator/UserSee/ScreenOne';
import CreateEmployee from './RetirementSimulator/CreateEmployee';
import BudgetPensin from './RetirementSimulator/UserSee/BudgetPension';
import AccrualPension from './RetirementSimulator/UserSee/AccrualPension';
import BudgetPensionForSeniorSalary from './RetirementSimulator/UserSee/BudgetPensionForSeniorSalary';
import GeneralData from './RetirementSimulator/UserSee/GeneralData';


function App() {
  return (
    <div className='App-header'>
     <BrowserRouter>
     {/* <Api></Api> */}
     {/* <CreateEmployee></CreateEmployee> */}
     
        <Routes>
        <Route exact path="/" element={<LoginPage></LoginPage>}/>
         <Route exact path="ScreenOne" element={<ScreenOne></ScreenOne>}></Route>
         <Route exact path='BudgetPensin' element = {<BudgetPensin></BudgetPensin>}></Route>
         <Route exact path='AccrualPension' element = {<AccrualPension></AccrualPension>}></Route>
         <Route exact path='BudgetPensionForSeniorSalary' element = {<BudgetPensionForSeniorSalary></BudgetPensionForSeniorSalary>}></Route>
         <Route exact path='GeneralData' element = {<GeneralData></GeneralData>}></Route>
         </Routes>
      </BrowserRouter>

     
    </div>
  );
}

export default App;
