import { render } from "../node_modules/lit-html/lit-html.js";
import {allCatsTemplate} from'./templates/catsTemplates.js';
import {cats} from './catSeeder.js'

let catsContainer = document.getElementById('allCats');
render(allCatsTemplate(cats, toggleStatus), catsContainer);

function toggleStatus(e){
    if(!e.target.classList.contains('showBtn')) return;

    let statusButton = e.target;
    let show = statusButton.textContent === 'Show status code';
    let parentDiv = statusButton.closest('.info');
    let statusDiv = parentDiv.querySelector('.status');

    statusButton.textContent = show? 'Hide status code': 'Show status code';
    
    if(show){
        statusDiv.classList.remove('hidden');
    }else{
        statusDiv.classList.add('hidden');
    }
}