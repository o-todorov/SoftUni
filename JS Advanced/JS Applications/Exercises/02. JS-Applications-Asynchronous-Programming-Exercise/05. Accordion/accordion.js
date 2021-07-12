function solution() {
    const listUrl = 'http://localhost:3030/jsonstore/advanced/articles/list';
    const detailsBaseUrl = 'http://localhost:3030/jsonstore/advanced/articles/details/';
    HTMLElement.prototype.addElement = addElement;

    fetch(listUrl)
        .then(res => res.json())
        .then(list => {
            let section = document.getElementById('main');
            Object.values(list).forEach(x => {
                let newArticle = createArticleHTML(x);
                section.appendChild(newArticle);
            });
        })

    function createArticleHTML({_id, title}){
        let articleDiv = createElement('div', ['class', 'accordion']);

        let articleHeadDiv  = articleDiv.addElement('div', ['class', 'head']);
        let titleSpan       = articleHeadDiv.addElement('span', title);
        let morelessButton  = articleHeadDiv.addElement('button', 'More', ['id', '_id'], ['class', 'button']);
        morelessButton.addEventListener('click', showMoreLess);
        let articleExtraDiv = articleDiv.addElement('div', ['class', 'extra'], ['style', 'display: block;'], ['title_id', _id]);
        let extraPara       = articleExtraDiv.addElement('p');

        return articleDiv;
    }

    async function showMoreLess(e){
        let moreButton = e.target;
        let extraDiv = moreButton.closest('.accordion').querySelector('.extra');
    
        if(e.target.textContent == 'More'){
            let textP = extraDiv.querySelector('p');
    
            if(textP.textContent ==''){
                let id = extraDiv.getAttribute('title_id');
                let req = await fetch(`${detailsBaseUrl}/${id}`);
                textP.textContent = (await req.json()).content;
            }
    
            extraDiv.style.display = 'block';
            moreButton.textContent = 'Less';
        }else{
            extraDiv.style.display = 'none';
            moreButton.textContent = 'More';
        }
    }
}

function addElement(tag, ...args) { 
    let e =  createElement(tag, ...args);
    return this.appendChild(e);
}

function createElement(tag, ...args){
    let e =  document.createElement(tag);
    args.forEach(x => {typeof x === 'string'? e.textContent = x:
            Array.isArray(x)? e.setAttribute(x[0], x[1]): e.appendChild(x);
    });

    return e;
}

solution();

