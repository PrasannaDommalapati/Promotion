import ActionType from '../ActionType';

const userReducer = (state = [], action) => {
    switch (action.type) {
        case ActionType.GET_USER:
            return [...state, { ...action.payload }];
        case ActionType.GET_USER_LIST:
            return [...state, { ...action.payload }]
        default:
            return state;
    }
}

export default userReducer;