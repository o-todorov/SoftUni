function solve() {
  var sentences = document.querySelector('#input').value
                      .split(/ *\. */)
                      .filter(x => x)
                      .map(x => x + '.');
  
  let output = document.querySelector('#output');

  for (let i = 0; i < sentences.length; i++) {
    let p = document.createElement('p');
    p.appendChild(document.createTextNode(sentences.slice(i, i + 3).join('')));
    output.appendChild(p);
    i += 2;   
  }
}

function solve1() {
  var sentences = document.querySelector('#input').value
                      .split(/ *\. */)
                      .filter(x => x)
                      .map(x => x + '.');
  
  let paragraphs = document.createElement('div');
  paragraphs.setAttribute('id', 'output');

  for (let i = 0; i < sentences.length; i++) {
    let p = document.createElement('p');
    p.appendChild(document.createTextNode(sentences.slice(i, i + 3).join('.')));
    paragraphs.appendChild(p);   
    i += 2;   
  }

  let output = document.querySelector('#output');
  output.parentElement.replaceChild(paragraphs, output);
}