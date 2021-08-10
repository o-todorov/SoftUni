    const baseURL = 'http://localhost:3030/jsonstore/collections/books';
    let loadBooksButton = document.querySelector('#loadBooks');
    loadBooksButton.addEventListener('click', loadBooks);

    let tableBody = document.querySelector('.books');
    tableBody.addEventListener('click', updateEntry);

    let submitForm = document.querySelector('#form');
    submitForm.addEventListener('submit', submit);

    let submitButton = submitForm.querySelector('#submit');
    let cancelButton = submitButton.insertAdjacentElement(
                "afterend", createElement('button', 'Cancel', ['style', 'display:none;']));
    cancelButton.addEventListener('click', cancelEditState); 

let reqMethod = {
    post: (obj) => {return {method: 'post', headers: {'Content-Type': 'application/json'}, body: JSON.stringify(obj)}},
    patch: (obj) => {return {method: 'patch', headers: {'Content-Type': 'application/json'}, body: JSON.stringify(obj)}},
    put: (obj) => {return {method: 'put', headers: {'Content-Type': 'application/json'}, body: JSON.stringify(obj)}},
}

let actions = {
    edit(id){
        let bookTR = document.getElementById(id);
        let author = bookTR.querySelector('.author').textContent;
        let title = bookTR.querySelector('.title').textContent;
        submitForm.querySelector('input[name="author"]').value = author;
        submitForm.querySelector('input[name="title"]').value = title;
        submitForm.dataset.bookId = id;
        submitButton.textContent = 'Apply changes';
        submitButton.setAttribute('state', 'update');
        cancelButton.style.display = 'block';
        submitForm.querySelector('h3').textContent = 'Edit book';
    },
    update(id){
        let book = getBookFromForm();
        let bookTR = document.getElementById(id);
        bookTR.querySelector('.author').textContent = book.author;
        bookTR.querySelector('.title').textContent = book.title;
        saveBook(book, create = false, id);
        cancelEditState();
    },
    async create(){
        let book = getBookFromForm();
        try {
            let saveRequest = await (saveBook(book, create = true));
            if(!saveRequest || !saveRequest.ok) return;
            book._id = (await saveRequest.json())._id;
            submitForm.reset();
            tableBody.appendChild(createBookTR(book));
        } catch (err) {
            console.log(`Error while creating new book.\nError message: ${err}`);
        }

    },
    delete(id){
        document.getElementById(id).remove();

        fetch(`${baseURL}/${id}`, {method: 'delete'})
        .then(res => res.json())
        .catch(err => console.log(`Error while deleting the entry.\nError message: ${err}`));
    }
}

// functionality:

function cancelEditState(e){
    if(e) e.preventDefault();
    submitButton.setAttribute('state', 'create');
    submitButton.textContent = 'Submit';
    submitForm.querySelector('h3').textContent = 'Create book';
    submitForm.reset();
    cancelButton.style.display = 'none';
}

async function loadBooks(){
    try {
        let bookRequest = await fetch(baseURL);
        let books = await bookRequest.json();
        fillTableBody(books);
    } catch (err) {
        console.log(`Error loading books\nError: ${err}`);
    }
}

function submit(e){
    e.preventDefault();
    let state = submitButton.getAttribute('state');
    actions[state](submitForm.dataset.bookId);
}

function updateEntry(e){
    if(e.target.tagName != 'BUTTON') return;
    let [code, id] = e.target.id.split('_');
    actions[code](id);
}


function saveBook(book, create, id){
    if(!book.author || !book.title){
        window.alert('Missing details about the book!\nMust have Title and Author!');
        return false;
    }
    if(create){
        return fetch(baseURL, reqMethod.post(book))
    }else{
        return fetch(`${baseURL}/${id}`, reqMethod.put(book))
    }
}

function getBookFromForm(){
    let formData = new FormData(submitForm);
    return {
        author: formData.get('author'),
        title: formData.get('title')
    }
}

function fillTableBody(books){
    [...tableBody.children].forEach(x => x.remove());
    let rows = Object.values(books)
                    .map(createBookTR);
    tableBody.append(...rows);
}

function createBookTR(book){
    return createElement('tr', ['id', book._id], 
                    createElement('td', book.title, ['class', 'title']),
                    createElement('td', book.author, ['class', 'author']),
                    createElement('td', createElement('button', 'Edit', ['id', `edit_${book._id}`]),
                                        createElement('button', 'Delete', ['id', `delete_${book._id}`]) ));
}

function createElement(tag, ...args){
        let e =  document.createElement(tag);
        args.forEach(x => {
            typeof x === 'string' || typeof x === 'number'? e.textContent = x:
            Array.isArray(x)? e.setAttribute(x[0], x[1]): e.appendChild(x);
        });
        return e;
}

