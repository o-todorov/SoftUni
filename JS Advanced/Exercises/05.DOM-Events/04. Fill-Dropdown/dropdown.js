function addItem() {
    let select = document.querySelector('#menu');
    let newItemTextElement = document.querySelector('#newItemText');
    let newItemValueElement = document.querySelector('#newItemValue');
    let option = document.createElement('option');
    option.textContent = newItemTextElement.value;
    option.value = newItemValueElement.value;
    select.appendChild(option);

    newItemTextElement.value = '';
    newItemValueElement.value = '';
}