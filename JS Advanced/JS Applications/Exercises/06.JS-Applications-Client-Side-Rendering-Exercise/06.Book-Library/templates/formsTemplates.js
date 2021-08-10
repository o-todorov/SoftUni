import { html } from "../../node_modules/lit-html/lit-html.js";
import { ifDefined } from "../../node_modules/lit-html/directives/if-defined.js";

let hiddenInput = (id) => 
    id? html`<input type="hidden" name="id" value="${id}">` :'';

let cancelButton = (cancelHandler) => 
cancelHandler? html`<input type="button" value="Cancel" @click=${cancelHandler}>` :'';

export let formTemplate = (form) => html`
    <form id="${form.id}" @submit=${form.submitHandler}>
        ${hiddenInput(form.bookId)}
        <h3>${form.caption}</h3>
        <label>TITLE</label>
        <input type="text" value=${ifDefined(form.bookTitle)} name="title" placeholder="Title...">
        <label>AUTHOR</label>
        <input type="text" value=${ifDefined(form.bookAuthor)}  name="author" placeholder="Author...">
        <input type="submit" value="${form.submitText}">
        ${cancelButton(form.cancelHandler)}
    </form>
`