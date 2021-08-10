import {html} from '../../node_modules/lit-html/lit-html.js';
import { formTownsTemplate } from './formTemplate.js';
 export let bodyTemplate = () => html`    
        ${formTownsTemplate()}
        <div id="root">
        </div>
    `