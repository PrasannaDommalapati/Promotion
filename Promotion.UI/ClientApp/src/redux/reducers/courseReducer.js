import ActionType from '../ActionType';

const courseReducer = (state = [], action) => {

    switch (action.type) {
        case ActionType.CREATE_COURSE:
            return action.payload;
        default:
            return state;
    }
}

export default courseReducer;