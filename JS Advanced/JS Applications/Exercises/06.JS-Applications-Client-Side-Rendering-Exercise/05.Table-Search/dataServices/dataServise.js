import {jsonRequest, reqMethod} from './jsonQueries.js';
let url = 'http://localhost:3030/jsonstore/advanced/table';

export let data = {
    get,
    add
}
async function get(id = ''){
    return await jsonRequest(`${url}/${id}`, reqMethod.get());
}
async function add(item){
    return await jsonRequest(url, reqMethod.post(body = item));
}