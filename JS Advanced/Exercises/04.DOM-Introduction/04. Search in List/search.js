function search() {
   let towns = Array.from(document.querySelector('#towns').children);

   let result = document.querySelector('#result');
   result.textContent = '';

   towns.forEach(t =>  t.removeAttribute('style'));

   let text = document.querySelector('#searchText').value;
   if(text == '') return;

   let selectedstyle = 'font-weight: bold; text-decoration: underline';
   let matched = towns.filter(e => e.textContent.includes(text));
   matched.forEach(e => e.setAttribute('style', selectedstyle));

   result.textContent = `${matched.length} matches found`;
}
