import ActionType from '../ActionType';
import { fetchUser, fetchUserList } from '../../services/ApiCalls'

export const getUserAction = () => {
    return dispatch => fetchUser(2)
        .then(user => {
            dispatch({
                type: ActionType.GET_USER,
                payload: user
            });
        });
}

export const getUserListAction = () => {
    return dispatch => fetchUserList()
    .then(users => {
        dispatch({
            type: ActionType.GET_USER_LIST,
            payload: users
        })
    })
}

