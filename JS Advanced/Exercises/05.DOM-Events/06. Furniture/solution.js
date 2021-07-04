function solve() {
  let buttons = document.querySelectorAll('#exercise button');
  buttons[0].addEventListener('click', generateItem);
  buttons[1].addEventListener('click', buyItem);
  let [inputArea, boughtArea] = [...document.querySelectorAll('#exercise textarea')];
  let tbody = document.querySelector('tbody');

  function generateItem(){
    JSON.parse(inputArea.value)
        .forEach(item => {
          let tr = document.createElement('tr');
          let tds = Array.from({length:5}, () => document.createElement('td'));

          tds[0].appendChild(document.createElement('img')).src = item.img;
          tds[1].appendChild(document.createElement('p')).textContent = item.name;
          tds[2].appendChild(document.createElement('p')).textContent = item.price;
          tds[3].appendChild(document.createElement('p')).textContent = item.decFactor;
          tds[4].appendChild(document.createElement('input')).type = 'checkbox';

          tds.forEach((x) => tr.appendChild(x));
          tbody.appendChild(tr);
        });
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

    boughtArea.value = `Bought furniture: ${names}
Total price: ${totalPrice}
Average decoration factor: ${avgDecFactor}`;
  }
}