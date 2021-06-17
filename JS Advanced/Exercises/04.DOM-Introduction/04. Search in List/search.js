function search() {
   let towns = Array.from(document.querySelector('#towns').children);

   let result = document.querySelector('#result');
   result.textContent = '';

   for (let townname of towns) {
      townname.removeAttribute('style');
   }

   let text = document.querySelector('input[type="text"]').value;
   if(text == '') return;

   let matched = towns.filter(e => e.textContent.includes(text));

   result.textContent = `${matched.length} matches found`;
   
   let selectedstyle = 'font-weight: bold; text-decoration: underline';
   matched.forEach(e => e.setAttribute('style', selectedstyle));
}
