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
            .filter(r => r.children[4].children[0].checked)
            .map(r => {return {name: r.children[1].textContent,
                              price: Number(r.children[2].textContent),
                              decFactor: Number(r.children[3].textContent)}});

    let names           = rows.reduce((arr, x) => {arr.push(x.name); return arr;}, []);  
    let totalPrice      = rows.reduce((t, x) => t + x.price, 0);  
    let totalDecFactor  = rows.reduce((t, x) => t + x.decFactor, 0);  
    let avgDecFactor    = totalDecFactor / rows.length;

    boughtArea.value = `Bought furniture: ${names.join(', ')}\n`;
    boughtArea.value += `Total price: ${totalPrice.toFixed(2)}\n`;
    boughtArea.value += `Average decoration factor: ${avgDecFactor}`;
  }
}