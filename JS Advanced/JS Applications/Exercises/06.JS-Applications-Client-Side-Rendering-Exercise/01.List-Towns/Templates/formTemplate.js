import {html} from '../../node_modules/lit-html/lit-html.js';
 export let formTownsTemplate = () => html`
    <form id="form-towns" action="#" class="content">
        <label for="towns">Towns</label>
        <input id="towns" name="towns" type="text" />
        <button id="btnLoadTowns">Load</button>
    </form>`