import * as Faker from 'faker';

export default {
    documentList: [
        {
            name: Faker.system.fileName(),
            type: Faker.system.fileType(),
            size: Faker.random.number()
        },
        {
            name: Faker.system.fileName(),
            type: Faker.system.fileType(),
            size: Faker.random.number()
        },
        {
            name: Faker.system.fileName(),
            type: Faker.system.fileType(),
            size: Faker.random.number()
        }
    ],
    posts: [{
        id: 1,
        name: "cerulean",
        year: 2000,
        color: "#98B2D1",
        pantone_value: "15-4020"
    },
    {
        id: 1,
        name: "cerulean",
        year: 2000,
        color: "#98B2D1",
        pantone_value: "15-4020"
    },
    {
        id: 1,
        name: "cerulean",
        year: 2000,
        color: "#98B2D1",
        pantone_value: "15-4020"
    }],


    documentRequests: [
        {
            referenceId: "3417028b-d716-4d47-9d82-971f5d44b5b2",
            requesterId: "test request 1",
            statusMessage: "Queued For Composition",
            dateCreated: "2019-05-02T13:36:35.2553019",
            dateModified: "2019-05-02T13:36:36.3553019"
        },
        {
            referenceId: "3417028b-d716-4f4e-9d82-971f5d44b5b2",
            requesterId: "test request 2",
            statusMessage: "Queued For Composition",
            dateCreated: "2019-05-02T13:36:35.2553019",
            dateModified: "2019-05-02T13:36:36.3553019"
        }
    ]
}
