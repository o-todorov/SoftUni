function toggle() {
    let toggleButton = document.querySelector('.head .button');
    let extraText = document.querySelector('#extra');

    if(toggleButton.textContent === 'More'){
        toggleButton.textContent = 'Less';
        extraText.setAttribute('style', 'display:block');
    }else{
        toggleButton.textContent =  'More';
        extraText.setAttribute('style', 'display:none');
    }
}