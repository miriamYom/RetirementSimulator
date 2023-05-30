import { combineReducers } from "redux";
import employeeReducer from './employeeReducer';

const allReducers = combineReducers({
    employeeReducer: employeeReducer,
});

export default allReducers;