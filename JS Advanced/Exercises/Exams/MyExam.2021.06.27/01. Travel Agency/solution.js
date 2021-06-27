window.addEventListener('load', solution);

function solution() {
  let form = document.querySelector('#form');

  let submitButtonElement = form.querySelector('#submitBTN');
  submitButtonElement.addEventListener('click', submit);

  let previewElement = document.querySelector('#information');

  let editButtonElement = previewElement.querySelector('#editBTN');
  editButtonElement.disabled = true;
  editButtonElement.addEventListener('click', edit);

  let continueButtonElement = previewElement.querySelector('#continueBTN');
  continueButtonElement.disabled = true;
  continueButtonElement.addEventListener('click', sendData);

  let data = [];
  let inputFields = Array.from(form.querySelectorAll('div input'));

  function submit(e){
    e.preventDefault;
    let labelFields = Array.from(form.querySelectorAll('div label'))
                          .map(f => f.textContent);
    data = inputFields.map(f => f.value);
    if(data[0] == '' || data[0] == '') return;
    inputFields.forEach(i => i.value = '');

    let previewListElement = previewElement.querySelector('#infoPreview')
    let listItems = Array.from({length:5}, () => document.createElement('li'));
    listItems.forEach((li,i) =>{
      li.textContent = `${labelFields[i]} ${data[i]}`;
      previewListElement.appendChild(li);
      toggleButtons();
    })
  }
  
  function edit(){

    data.forEach((d, i) => {inputFields[i].value = d});
    let previewListElement = previewElement.querySelector('#infoPreview')

    while (previewListElement.firstChild) {
      previewListElement.removeChild(previewListElement.firstChild);
    }

    toggleButtons();
  }

  function sendData(){
    let blockDivElement = document.querySelector('#block');

    while(blockDivElement.firstChild){
      blockDivElement.removeChild(blockDivElement.firstChild);
    }

    let h3 = document.createElement('h3');
    h3.textContent = 'Thank you for your reservation!';
    blockDivElement.appendChild(h3);
  }
  function toggleButtons(){
    submitButtonElement.disabled = !submitButtonElement.disabled;
    editButtonElement.disabled = !editButtonElement.disabled;
    continueButtonElement.disabled = !continueButtonElement.disabled;
  }
}
