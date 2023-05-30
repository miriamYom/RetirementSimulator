// דע כי ה... הוא הנותן... לעשות חיל
//ריאקט מטריאל
//https://mui.com/material-ui/react-switch/
import "@fontsource/rubik";
import "./App.css";
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Header from './RetirementSimulator/Header';
import GeneralData from "./RetirementSimulator/GeneralData";
import PensionType from "./RetirementSimulator/PensionType";
import Details from "./RetirementSimulator/Details";
import PartTimeJob from "./RetirementSimulator/PartTimeJob";
import Calculation from "./RetirementSimulator/Calculation";
import Login from "./RetirementSimulator/Login";
import { Provider } from "react-redux";
import store from "./redux/store";


function App() {

  return (
    <div className="App">
      <Provider store={store}>
        <BrowserRouter>
          <Header></Header>
          <Routes>
            <Route exact path="/" element={<Login></Login>} />
            <Route exact path="PensionType" element={<PensionType></PensionType>}></Route>
            <Route exact path="GeneralData" element={<GeneralData></GeneralData>}></Route>
            <Route exact path="Details" element={<Details></Details>}></Route>
            <Route exact path="PartTimeJob" element={<PartTimeJob></PartTimeJob>}></Route>
            <Route exact path="Calculation" element={<Calculation></Calculation>}></Route>
          </Routes>
        </BrowserRouter>
      </Provider>
    </div>
  );
}

export default App;
