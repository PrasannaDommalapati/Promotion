import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux';

import courses from './courseReducer';
import users from './userReducer';

export default combineReducers({
    routing: routerReducer,
    courses,
    users
});
