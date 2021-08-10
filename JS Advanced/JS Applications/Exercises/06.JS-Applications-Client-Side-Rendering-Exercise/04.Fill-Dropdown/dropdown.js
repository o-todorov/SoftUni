import { render } from "../node_modules/lit-html/lit-html.js";
import { optionsTemplate } from "./dropDownTemplates.js";
let dropDownUrl = 'http://localhost:3030/jsonstore/advanced/dropdown';
let selectContainer = document.getElementById('menu');
let options = [];
let addButton = document.querySelector('#add-form input[type="submit"]');

loadOptions();
function loadOptions(){
    addButton.disabled = true;
    fetch(dropDownUrl)
    .then(req => {
        if(req.status != 200) throw (new Error(req.statusText));
        return req.json();
    })
    .then(optionsRes => {
        options = Object.values(optionsRes);
        render(optionsTemplate(options), selectContainer);
        addButton.disabled = false;
    })
    .catch(err => alert(err.message));
}

let addForm = document.getElementById('add-form');
addForm.addEventListener('submit', addItem);


async function addItem(e) {
    e.preventDefault();
    let formData = new FormData(addForm);
    let method = {method: 'post'};
    method.headers = {'Content-Type': 'application/json'};
    method.body = JSON.stringify({text: formData.get('option')});
    try {
        let postReq = await fetch(dropDownUrl, method);
        if(postReq.ok){
            let added = await postReq.json();
            options.push(added);
            render(optionsTemplate(options), selectContainer);
        }
    } catch (error) {
        console.log(error.message);
    }
    addForm.querySelector('#itemText').value = '';
}