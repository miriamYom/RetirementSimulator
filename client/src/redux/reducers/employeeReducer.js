const initialState = {};

const employeeReducer = (state = initialState, action) => {
    switch (action.type) {
        case "ADDDETAIL": {
            state[action.playload.name] = action.playload.value;
            return state;
        }
        case "ADDDETAILS": {
            // Object.keys(action.playload.obj).forEach(key => {
            //     state[key] = action.playload.obj[key];
            // });
            console.log(initialState);
            return state;
        }
    }
    return state;
}
export default employeeReducer;