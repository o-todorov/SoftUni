function addElement(tag, ...args) { 
    let e =  createElement(tag, ...args);
    return this.appendChild(e);
}

function createElement(tag, ...args){
    let e =  document.createElement(tag);
    args.forEach(x => {
        typeof x === 'string' || typeof x === 'number'? e.textContent = x:
        Array.isArray(x)? e.setAttribute(x[0], x[1]): e.appendChild(x);
    });
    return e;
}
export const {addElement, createElement};