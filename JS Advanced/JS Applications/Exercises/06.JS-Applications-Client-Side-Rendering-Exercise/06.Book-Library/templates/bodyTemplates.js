import { html } from "../../node_modules/lit-html/lit-html.js";

let tableTemplate =  html`
    <table>
        <thead>
            <tr>
                <th>Title</th>
                <th>Author</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody id="books-container">
        </tbody>
    </table>
`

let loadButtonTemplate = (actions) => html`
    <button id="loadBooks" @click=${actions.loadBooks}>LOAD ALL BOOKS</button>
`

export let bodyTemplate = (actions) => html`
    ${loadButtonTemplate(actions)}
    ${tableTemplate}
    <div id="form-container"></div>
`