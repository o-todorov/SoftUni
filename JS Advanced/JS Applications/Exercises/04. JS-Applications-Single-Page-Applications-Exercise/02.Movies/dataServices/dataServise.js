import {jsonRequest, requestMethod} from './jsonQueries.js';
let url = '';

export let setUrl = (newUrl) => url = newUrl;
export let data = {
    get,
    add,
    setUrl: (newUrl) => url = newUrl,
    replace,
    remove,
    update
}

async function get(id = '', token = ''){
    id = id?`/${id}`: '';
    return await jsonRequest(`${url}${id}`, requestMethod.get(token));
}

async function add(item, token){
    return await jsonRequest(url, requestMethod.post(item, token));
}

async function replace(id, item, token){
    return await jsonRequest(`${url}/${id}`, requestMethod.put(item, token));
}

async function update(id, item, token){
    return await jsonRequest(`${url}/${id}`, requestMethod.patch(item, token));
}

async function remove(id, token){
    return await jsonRequest(`${url}/${id}`, requestMethod.delete(token));
}