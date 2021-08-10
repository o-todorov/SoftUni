import { html } from "../../node_modules/lit-html/lit-html.js";
//import { ifDefined } from "../../node_modules/lit-html/directives/if-defined.js";

export let buttonsTemplate = (actions) => html`
            <button @click=${actions.preEditBook}>Edit</button>
            <button @click=${actions.deleteBook}>Delete</button>
`
export let bookTemplate = (book, actions) => html`
            <tr id=${book.id}>
                <td class="title">${book.title}</td>
                <td class="author">${book.author}</td>
                <td>${buttonsTemplate(actions)}</td>
            </tr>
`

export let booksTemplate = (books, actions) => html`
    ${books.map(book => bookTemplate(book, actions))}
`
