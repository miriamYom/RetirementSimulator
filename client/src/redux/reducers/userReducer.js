const initialState = {"name":"ג'ודית"};

const userReducer = (state = initialState, action) => {
    switch (action.type) {
        case "USERLOGIN": {
            initialState = action.playload.obj;
            return state;
        }
    }
    return state;
}
export default userReducer;