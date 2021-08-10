import { html } from "../node_modules/lit-html/lit-html.js";

export let optionTemplate = (item) => html`
    <option .value=${item._id}>${item.text}</option>
`

export let optionsTemplate = (items) => html`
        ${items.map(item => optionTemplate(item))}
`