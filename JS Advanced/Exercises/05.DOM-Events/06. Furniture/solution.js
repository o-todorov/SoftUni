function solve() {
  let buttons = document.querySelectorAll('#exercise button');
  buttons[0].addEventListener('click', generateItem);
  buttons[1].addEventListener('click', buyItem);
  let textAreas = document.querySelectorAll('#exercise textarea');
  let inputArea = textAreas[0];
  let boughtArea = textAreas[1];
  let tbody = document.querySelector('tbody');

  function generateItem(){
    JSON.parse(inputArea.value)
        .forEach(item => {
          let tr = document.createElement('tr');
          let tds = Array.from({length:5}, () => document.createElement('td'));

          let img = document.createElement('img');
          img.src = item.img;

          tds[0].appendChild(img);
          tds[1].appendChild(createP(item.name));
          tds[2].appendChild(createP(item.price));
          tds[3].appendChild(createP(item.decFactor));

          let checkbox = document.createElement('input');
          checkbox.type = 'checkbox';
          tds[4].appendChild(checkbox);

          tds.forEach((x) => tr.appendChild(x));
          tbody.appendChild(tr);
        });
    function createP(value){
      let p = document.createElement('p');
      p.textContent = value;
      return p;
    }
  }

  function buyItem(){
    let rows = Array.from(tbody.querySelectorAll('tr'))
            .filter(r => r.querySelector('input:checked'))
            .map(r => {return {name: r.children[1].textContent,
                              price: Number(r.children[2].textContent),
                              decFactor: Number(r.children[3].textContent)}});

    let names           = rows.map(item => item.name).join(', ');  
    let totalPrice      = rows.reduce((t, item) => t + item.price, 0).toFixed(2);  
    let totalDecFactor  = rows.reduce((t, item) => t + item.decFactor, 0);  
    let avgDecFactor    = totalDecFactor / rows.length;

    boughtArea.value = `Bought furniture: ${names}\n`;
    boughtArea.value += `Total price: ${totalPrice}\n`;
    boughtArea.value += `Average decoration factor: ${avgDecFactor}`;
  }
}