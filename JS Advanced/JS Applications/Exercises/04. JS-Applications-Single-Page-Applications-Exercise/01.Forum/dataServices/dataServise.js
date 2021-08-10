import {jsonRequest, requestMethod} from './jsonQueries.js';
let url = '';

export let setUrl = (newUrl) => url = newUrl;
export let data = {
    get,
    add,
    setUrl: (newUrl) => url = newUrl,
    //replace,
    //remove,
    //update
}

async function get(id = ''){
    return await jsonRequest(`${url}/${id}`, requestMethod.get());
}

async function add(item){
    return await jsonRequest(url, requestMethod.post(item));
}
/*
async function replace(id, item){
    return await jsonRequest(`${url}/${id}`, requestMethod.put(item));
}

async function update(id, item){
    return await jsonRequest(`${url}/${id}`, requestMethod.patch(item));
}

async function remove(id){
    return await jsonRequest(`${url}/${id}`, requestMethod.delete());
}*/