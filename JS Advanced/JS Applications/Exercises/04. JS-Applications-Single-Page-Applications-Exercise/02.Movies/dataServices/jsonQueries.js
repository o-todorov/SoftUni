export async function jsonRequest(url, method){
    try {
        let response = await fetch(url, method);
        if (response.ok && !url.includes('logout')){
            return await response.json();
        }else{
            return response.status;
        }
    } catch (error) {
        window.alert(error.message);
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