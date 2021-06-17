function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let rows = Array.from(document.querySelectorAll('.container tbody tr'));
      rows.filter(r => r.classList.contains('select'))
            .forEach(r => r.removeAttribute('class'));
      let text = document.querySelector('#searchField').value;
      if(text == '') return;
      rows.forEach(r => {
         if(Array.from(r.children).some(td => td.textContent.toLowerCase().includes(text.toLowerCase()))){
            r.setAttribute('class', 'select');
         }
      })
   }
}