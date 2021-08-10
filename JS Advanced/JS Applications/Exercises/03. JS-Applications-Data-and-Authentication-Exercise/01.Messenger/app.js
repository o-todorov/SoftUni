function attachEvents() {
    const postsURL = 'http://localhost:3030/jsonstore/messenger';
    let messagesTextArea = document.querySelector('#messages');
    let authorInput = document.querySelector('input[name="author"]');
    let contentInput = document.querySelector('input[name="content"]');
    let submitButton = document.querySelector('#submit');
    let refreshButton = document.querySelector('#refresh');
    
    submitButton.addEventListener('click', () => {
        if(!authorInput.value || !contentInput.value) return;

        let post = {
            'author': authorInput.value,
            'content': contentInput.value
        }
        authorInput.value = contentInput.value = '';
        
        fetch(postsURL, {
            method: 'post',
            Headers:{'Content-Type': 'aplication/json'},
            body: JSON.stringify(post)
        });
    })
    refreshButton.addEventListener('click', () => {
        fetch(postsURL)
            .then(res => res.json())
            .then(posts => messagesTextArea.value =  
                Object.values(posts).map(p => `${p.author}: ${p.content}`).join('\n') )
            .catch(err => messagesTextArea.value = '');
    })
}

attachEvents();