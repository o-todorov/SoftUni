import {html} from '../../node_modules/lit-html/lit-html.js';
export let townTemplate  = (town) => html`
    <li>${town}</li>
`
export let townsTemplate  = (towns) => html`
    <ul>
        ${towns.map(town => townTemplate(town))}
    </ul>
    
`