let reqMethod = {
    post: (obj) => {return {method: 'post', headers: {'Content-Type': 'application/json'}, body: JSON.stringify(obj)}},
    patch: (obj) => {return {method: 'patch', headers: {'Content-Type': 'application/json'}, body: JSON.stringify(obj)}},
    put: (obj) => {return {method: 'put', headers: {'Content-Type': 'application/json'}, body: JSON.stringify(obj)}},
    get: () => {return {method: 'get', headers: {}}},
}

export  {reqMethod};