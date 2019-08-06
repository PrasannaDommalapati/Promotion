import courseReducer from '../../../redux/reducers/courseReducer'
import ActionType from '../../../redux/ActionType';

describe('posts reducer', () => {
    it('should returns inital state', () => {
        const newState = courseReducer(undefined, {});
        expect(newState).toEqual([]);
    });

    it('shuold return new state when received an action type', () => {
        let posts = [
            { title: "test1" },
            { title: "test2" },
            { title: "test3" },
            { title: "test4" }];

        const newState = courseReducer(undefined, {
            type: ActionType.CREATE_COURSE,
            payload: posts
        });
        expect(newState).toEqual(posts);
    });
})
