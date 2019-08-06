import { applyMiddleware, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import RootReducer from '../reducers/root-reducer';

export default function configureStore(initialState) {

    const middleware = [thunk];

    // In development, use the browser's Redux dev tools extension if installed
    const enhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

    return createStore(
        RootReducer,
        initialState,
        enhancers(applyMiddleware(...middleware)));
}