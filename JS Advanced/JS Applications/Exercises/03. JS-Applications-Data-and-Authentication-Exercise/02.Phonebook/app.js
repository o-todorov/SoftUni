function attachEvents() {
    const phonebookUrl = 'http://localhost:3030/jsonstore/phonebook';

    document.querySelector('#btnLoad').addEventListener('click', loadPhoneBook);

    document.querySelector('#btnCreate').addEventListener('click', () => {
        let personInput = document.querySelector('#person');
        let phoneInput = document.querySelector('#phone');

        let json = JSON.stringify({ person: personInput.value, phone: phoneInput.value });
        personInput.value = phoneInput.value = '';
        let postmethod = {method: 'post', headers: {'Content-Type': 'application/json'}, body: json}

        fetch(phonebookUrl, postmethod)
            .then(res => loadPhoneBook())
            .catch(err => console.log('Error in posting new entry'));
    })

    function loadPhoneBook(){
        let phoneUL = document.querySelector('#phonebook');
        [...(phoneUL.children)].forEach(x => x.remove());

        fetch(phonebookUrl)
            .then(res => res.json())
            .then(book => {
                let liArray = [...(Object.values(book))]
                    //.map(entry => [`${entry.person}: ${entry.phone}`, entry._id])
                    .map(createLi);
                phoneUL.append(...liArray);
            })
            .catch(err => console.log('Error while loading the phonebook'))
    }

    function createLi({_id, person, phone}){
        let li = document.createElement('li');
        li.textContent = text;
        li.id = id;
        let deleteButton = li.appendChild(document.createElement('button'));
        deleteButton.textContent = 'Delete';
        deleteButton.addEventListener('click', deleteEntry);
        return li;
    }

    function deleteEntry(e){
        let li = e.target.parentElement;

        fetch(`${phonebookUrl}/${li.id}`, {
                method: 'delete'
            })
            .then(res => li.remove())
            .catch(err => console.log('Error when trying to delete entry'));
    }

}

attachEvents();