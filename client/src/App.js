// דע כי ה... הוא הנותן... לעשות חיל
import "@fontsource/rubik"; 
import "./App.css";
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import LoginPage from './RetirementSimulator/else/LoginPage';
// import Api from './RetirementSimulator/Else/Api';
// import ScreenOne from './RetirementSimulator/UserSee/ScreenOne';
// import CreateEmployee from './RetirementSimulator/CreateEmployee';
// import BudgetPensin from './RetirementSimulator/UserSee/BudgetPension';
// import AccrualPension from './RetirementSimulator/UserSee/AccrualPension';
// import BudgetPensionForSeniorSalary from './RetirementSimulator/UserSee/BudgetPensionForSeniorSalary';
// import GeneralData from './RetirementSimulator/UserSee/GeneralData';
import Header from './RetirementSimulator/Header';
// import PreviousNext from './RetirementSimulator/PreviousNext';
// import Salary from "./RetirementSimulator/UserSee/ScreenThree/Salary";
// import PersonalData from "./RetirementSimulator/UserSee/ScreenTwo/PersonalData";
import Vacation from "./RetirementSimulator/UserSee/ScreenThree/Vacation";
import GeneralData from "./RetirementSimulator/GeneralData";
import PensionType from "./RetirementSimulator/PensionType";
import Start from "./Start";

function App() {
  return (
    <div className="App">
     <BrowserRouter>
     {/* <Api></Api> */}
     {/* <CreateEmployee></CreateEmployee> */}
     <Header></Header>
        <Routes>
        {/* <Route exact path="/" element={<LoginPage></LoginPage>}/> */}
        <Route exact path="/" element={<Start></Start>}/>
         <Route exact path="PensionType" element={<PensionType></PensionType>}></Route>
         <Route exact path="GeneralData" element={<GeneralData></GeneralData>}></Route>
         {/* <Route exact path='BudgetPensin' element = {<BudgetPensin></BudgetPensin>}></Route> */}
         {/* <Route exact path='AccrualPension' element = {<AccrualPension></AccrualPension>}></Route> */}
         {/* <Route exact path='BudgetPensionForSeniorSalary' element = {<BudgetPensionForSeniorSalary></BudgetPensionForSeniorSalary>}></Route> */}
         {/* <Route exact path='GeneralData' element = {<GeneralData></GeneralData>}></Route> */}
         {/* <Route exact path="Salary" element = {<Salary></Salary>}></Route> */}
         {/* <Route exact path="ParsonalData" element = {<PersonalData></PersonalData>}></Route> */}
         <Route exact path="Vacation" element = {<Vacation></Vacation>}></Route>
         </Routes>
      </BrowserRouter>
     
    </div>
  );
}

export default App;
