export async function jsonRequest(url, method){
    try {
        let request = await fetch(url, method);
        if (request.ok){
            return await request.json();
        }
    } catch (error) {
        console.log(error.message);
        return false;
    }
}

export let requestMethod = {
    get:    (token)         => getOptions('get', false, token),
    post:   (body, token)   => getOptions('post', body, token),
    put:    (body, token)   => getOptions('put', body, token),
    patch:  (body, token)   => getOptions('patch', body, token),
    delete: (token)         => getOptions('delete', false , token),
}

function getOptions(method, body, token){
    let options = {method, headers: {'Content-Type': 'application/json'}};
    if(token) options.headers['X-Authorization'] = token;
    if(body) options.body = JSON.stringify(body);
    return options;
}