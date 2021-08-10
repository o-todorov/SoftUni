import { render } from '../node_modules/lit-html/lit-html.js';
import { bodyTemplate } from './templates/bodyTemplates.js';
import { booksTemplate } from './templates/bookTemplates.js';
import { formTemplate } from './templates/formsTemplates.js';
import { data } from './dataServices/dataServise.js';

let actions = {
    loadBooks,
    editBook,
    preEditBook,
    cancelEdit,
    deleteBook,
    createBook
}
import { addForm, editForm} from './store/forms.js';

render(bodyTemplate(actions), document.body);
let booksContainer = document.getElementById('books-container');
let books = [];

async function loadBooks(){
    let booksObj = await data.get();
    books = Object.entries(booksObj)
        .map(([id, book]) => {book.id = id; return book});
    render(booksTemplate(books, actions), booksContainer);
    render(formTemplate(addForm(actions)),document.getElementById('form-container'));
}

function preEditBook(e){
    let bookTR = e.target.closest('tr');
    let eForm = editForm(actions);
    eForm.bookId = bookTR.id;
    eForm.bookTitle = bookTR.querySelector('.title').textContent;
    eForm.bookAuthor = bookTR.querySelector('.author').textContent;
    render(formTemplate(eForm),document.getElementById('form-container'));
}

async function editBook(e){
    e.preventDefault();
    let formData = new FormData(e.target)
    let book = {title: formData.get('title'),
                author: formData.get('author')
            }
    let id = formData.get('id');
    let result = await data.replace(id, book);
    if(result){
        let bookTR = document.getElementById(id);
        bookTR.querySelector('.title').textContent = book.title;
        bookTR.querySelector('.author').textContent = book.author;
    }
    cancelEdit();
}

function cancelEdit(e){
    render(formTemplate(addForm(actions)),document.getElementById('form-container'));
}

async function deleteBook(e){
    let bookTR = e.target.closest('tr');
    let result = await data.remove(bookTR.id);
    console.log(result)
    if(result) {
        loadBooks();
    }
}

async function createBook(e){
    e.preventDefault();
    let formData = new FormData(e.target)
    let book = {title: formData.get('title'),
                author: formData.get('author')
            }
    let result = await data.add(book);
    console.log(result)
    if(result) {
        e.target.reset();
        loadBooks();
    }
}
