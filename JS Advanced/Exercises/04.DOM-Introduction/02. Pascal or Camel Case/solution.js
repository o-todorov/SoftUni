function solve() {

  let input = document.getElementById('text').value;
  let rule = document.getElementById('naming-convention').value;

  document.getElementById('result').textContent = convert(input, rule);

  function convert(txt, rule){
    txt = txt.split(' ')
            .filter(x => x)
            .map(capitaliseFirstLetter);

    if(rule === 'Camel Case'){
      txt[0] = txt[0][0].toLowerCase()  + txt[0].slice(1);
    }else if(rule != 'Pascal Case'){
      return 'Error!';
    }
    return txt.join('');
  }

  function capitaliseFirstLetter(word){
    return word[0].toUpperCase() + word.slice(1).toLowerCase();
  }
}