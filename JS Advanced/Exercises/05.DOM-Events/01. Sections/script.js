function create(words) {
   let container = document.querySelector('#content');
   container.addEventListener('click', onclick);

   words.forEach(word => {
      let para = document.createElement('p');
      para.textContent = word;
      para.style.display = 'none';
      let div = document.createElement('div');
      div.appendChild(para);
      container.appendChild(div);
   });


   function onclick(event){
      if(event.target.matches('#content div')){
         event.target.firstChild.style.display = 'block';

      /*if(event.target.parentElement.tagName = 'content'){
         event.target.firstChild.style.display = 'block';
      content*/
      }
   }
}