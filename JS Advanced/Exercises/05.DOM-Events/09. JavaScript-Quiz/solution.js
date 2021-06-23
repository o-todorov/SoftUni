function solve() {
  let sections = Array.from(document.querySelectorAll('#quizzie section'));
  sections.forEach(s => s.addEventListener('click', onClick));
  let answers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
  let results = [];

  function onClick(e){
    let section = e.currentTarget;
    let target = e.target;

    if(target.className = 'answer-text'){
      results.push(target.textContent);
      section.style.display = 'none';
      let next = section.nextElementSibling;

      if(next.tagName.toLowerCase() == 'section'){
        next.style.display = 'block';
      }else{
        let outputElement = document.querySelector('#results .results-inner h1');
        let expected = results.length;
        let actual = compareArr(results, answers);

        outputElement.textContent = expected == actual ?
                          'You are recognized as top JavaScript fan!' :
                          `You have ${actual} right answers`;

        outputElement.parentElement.parentElement.style.display = 'block';
      }
    }

    function compareArr(arr1, arr2){
      return arr1.reduce((a, x, i) => {if(x == arr2[i])  a++; 
                 return a;
                }, 0);
    }
  }
}