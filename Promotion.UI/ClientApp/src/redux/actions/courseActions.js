import ActionType from '../ActionType';
import {fetchUser} from '../../services/ApiCalls'

export const createCourse = () => {
    return dispatch=> fetchUser(2)
    .then(posts => {
        dispatch({
            type: ActionType.CREATE_COURSE,
            payload: posts
        });
    });
}

export const getUserAction = () => {
    return dispatch=> fetchUser(2)
    .then(posts => {
        dispatch({
            type: ActionType.CREATE_COURSE,
            payload: posts
        });
    });
}