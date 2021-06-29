function solve(){
   let formCreate = document.querySelector('aside form');
   let buttonCreate = document.querySelector('button.btn.create');
   buttonCreate.addEventListener('click', createPost);
   let archiveElement = document.querySelector('.archive-section ol');
   let archive = [];

   function createPost(event){
      event.preventDefault();
      let art = document.createElement('article');

      art.appendChild(document.createElement('h1'))
         .textContent = formCreate.querySelector('#title').value;

      let p = art.appendChild(document.createElement('p'));
      p.textContent = 'Category: ';
      p.appendChild(document.createElement('strong'))
         .textContent = formCreate.querySelector('#category').value;

      p = art.appendChild(document.createElement('p'));
      p.textContent = 'Creator:';
      p.appendChild(document.createElement('strong'))
         .textContent = formCreate.querySelector('#creator').value;

      art.appendChild(document.createElement('p'))
         .textContent = formCreate.querySelector('#content').value;

      let div = document.createElement('div');
      div.classList.add('buttons');
      let buttonDelete = div.appendChild(document.createElement('button'));
      buttonDelete.classList.add('btn', 'delete');
      buttonDelete.textContent = 'Delete';

      let buttonArchive = div.appendChild(document.createElement('button'));
      buttonArchive.classList.add('btn', 'archive');
      buttonArchive.textContent = 'Archive';

      art.appendChild(div);
      art.addEventListener('click', processPost);
      document.querySelector('div[class="site-content"] section').appendChild(art);

      Array.from(formCreate.querySelectorAll('input, textarea')).forEach(e => e.value = '');
   }

   function processPost(e){
      if(!e.target.matches('button')) return;

      let process = {
         'Delete': () => {
            e.currentTarget.remove();
         },
         'Archive': () => {
            let artTitle = e.currentTarget.querySelector('h1').textContent;
            e.currentTarget.remove();
            archiveElement.appendChild(document.createElement('li')).textContent = artTitle;
            Array.from(archiveElement.children)
                  .sort((a, b) => a.textContent.localeCompare(b.textContent))
                  .forEach(a => archiveElement.appendChild(a));
         }
      };

      process[e.target.textContent]();
   }
  }

