export async function jsonRequest(url, method){
    try {
        let request = await fetch(url, method);
        if (request.ok){
            return await request.json();
        }
    } catch (error) {
        console.log(error.message);
    }
}

export let reqMethod = {
    get:    (token)         => getMethod('get', false, token),
    post:   (body, token)   => getMethod('post', body, token),
    put:    (body, token)   => getMethod('put', body, token),
    patch:  (body, token)   => getMethod('patch', body, token),
    delete: (token)         => getMethod('patch', false , token),
}

function getMethod(method, body, token){
    let options = {method, headers: {'Content-Type': 'application/json'}};
    if(token) options.headers['X-Authorization'] = token;
    if(body) options.body = JSON.stringify(body);
    return options
}