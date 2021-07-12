function attachEvents() {
    const postURL = 'http://localhost:3030/jsonstore/blog/posts';
    const commentsURL = 'http://localhost:3030/jsonstore/blog/comments';

    let btnLoadPosts = document.querySelector('#btnLoadPosts');
    btnLoadPosts.addEventListener('click', loadPosts);
    let btnViewPost = document.querySelector('#btnViewPost');
    btnViewPost.addEventListener('click', viewPost);
    let postsSelect = document.querySelector('#posts');


    async function loadPosts(e){
        [...(postsSelect.children)].forEach(x => x.remove());
        await fetch(postURL)
            .then(res => res.json())
            .then(posts => {
                let optionsArray = Object.values(posts)
                        .map(({id, title}) => createElement('option', title, ['value', id]));
                postsSelect.append(...optionsArray);
                    
            });
    }

    async function viewPost(){
        let postID = postsSelect.value;
        let currPost = await fetch(`${postURL}/${postID}`).then(res => res.json());

        fetch(commentsURL)
            .then(res => res.json())
            .then(comments => {
                let currComments = [...Object.values(comments)].filter(x => x.postId == postID);
                createHtmlPost(currComments);
            });

        function createHtmlPost(comments){
            document.getElementById('post-title').textContent = currPost.title;
            document.getElementById('post-body').textContent = currPost.body;

            let postComments = document.getElementById('post-comments');
            [...(postComments.children)].forEach(x => x.remove());

            comments.forEach(x => postComments.appendChild(createElement('li', ['id', x.id], x.text)));
        }
    }
}

function createElement(tag, ...args){
    let e =  document.createElement(tag);
    args.forEach(x => {typeof x === 'string'? e.textContent = x:
            Array.isArray(x)? e.setAttribute(x[0], x[1]): e.appendChild(x);
    });

    return e;
}

attachEvents();