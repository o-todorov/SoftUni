function solve() {
    document.querySelector('button').addEventListener('click', onclick);

    let select = document.querySelector('#selectMenuTo');
    select.appendChild(createOption('Binary')); 
    select.appendChild(createOption('Hexadecimal')); 

    function onclick(){
        let number = Number(document.querySelector('#input').value);

        let result = document.querySelector('#result');
    
        if(!select.value) return;
    
        if(select.value == 'binary'){
            result.value = number.toString(2).toUpperCase();
        }else if(select.value == 'hexadecimal'){
            result.value = number.toString(16).toUpperCase();
        }
    }

    function createOption(caption){
        let option = document.createElement('option');
        option.value = caption.toLowerCase();
        option.text = caption;
        return option;
    }
}