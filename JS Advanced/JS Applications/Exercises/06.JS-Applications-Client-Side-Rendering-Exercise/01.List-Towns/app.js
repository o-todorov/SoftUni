import {render} from '../node_modules/lit-html/lit-html.js';
import {townsTemplate} from './Templates/townsTemplates.js';
import {bodyTemplate} from './Templates/bodyTemplate.js';
render(bodyTemplate(), document.body);

let townsForm = document.querySelector('#form-towns');
townsForm.addEventListener('submit', loadTowns);

function loadTowns(e){
    e.preventDefault();
    let formData = new FormData(townsForm);
    let townsString = formData.get('towns');
    let towns = townsString.split(', ').filter(x => x);
    let rootElement = document.querySelector('#root');
    render(townsTemplate(towns), rootElement);
}