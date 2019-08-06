export const fetchDocumentRequestsByFilter = async (filter) => {

    const response = await fetch('api/requests/filter',{
        method: "POST", 
        cache: "no-cache", 
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(filter)
    });

    if(response.status<400){
        return await response.json();
    }

    throw (new Error('Unable to get document requests for supplied filter'));
}

export const fetchUser = async (id) =>{
    const response = await fetch(`api/promotion/users/${id}`);
    if(response.status <400){

        return await response.json();
    }
    throw (new Error(`Unable to get user details for ${id}.`));
}

export const fetchUserList = async () => {
    const response = await fetch(`api/rest/unknown`);
    if(response.status <400){

        return await response.json();
    }
    throw (new Error(`Unable to get list of posts.`));
}

