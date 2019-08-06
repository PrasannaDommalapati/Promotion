import { fetchUser } from '../../services/ApiCalls'

describe('apiCalls', () => {
    describe('fetch user suite', () => {
        let user = JSON.stringify([
            {
                id: 1,
                email: "janet.weaver@reqres.in",
                first_Name: "Janet",
                avatar: "https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg",
                last_Name: "Weaver"
            }]);

        it('returns a list of posts on success', () => {
            window.fetch = jest.fn()
                .mockImplementation(() => ({
                    status: 200,
                    json: () => Promise.resolve(user)
                }));

            expect(fetchUser()).resolves.toEqual(user);
        });

        it('throw an error on failure', () => {
            const id= 2;
            window.fetch = jest.fn()
                .mockImplementation(() => (
                    {
                        status: 500
                    }
                ));

            expect(fetchUser(id)).rejects.toEqual(Error(`Unable to get user details for ${id}.`));
        });
    })
})
