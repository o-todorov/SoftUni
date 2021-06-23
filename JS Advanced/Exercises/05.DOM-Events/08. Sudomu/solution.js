function solve() {
    let buttons = document.querySelectorAll('#exercise button');
    buttons[0].addEventListener('click', check);
    buttons[1].addEventListener('click', clear);

    let tableElement         = document.querySelector('#exercise table');
    let tableBodyElement     = tableElement.querySelector('tbody');
    let outputMessageElement = document.querySelector('#check p');

    const borderstyles  = {winner: '2px solid green', looser: '2px solid red'}
    const colors        = {winner: 'green', looser: 'red'}
    const messages      = {winner: 'You solve it! Congratulations!', looser: 'NOP! You are not done yet...'}
    
    function check(){
        let matrix = Array
                        .from(tableBodyElement.querySelectorAll('tr'))
                        .map(r => Array.from(r.querySelectorAll('td input'))
                                    .map(input => input.value));
        let size    = matrix.length;
        let success = true;

        matrix.forEach(isValid);

        if(success){
            for (let i = 0; i < size; i++) {
                let arr = [];
                for (let j = 0; j < size; j++) {
                    arr.push(matrix[j][i]);                 
                }
                isValid(arr);              
            }
        }


        let factor = success?'winner':'looser';
        tableElement.style.border               = borderstyles[factor];
        outputMessageElement.style.color        = colors[factor];
        outputMessageElement.textContent        = messages[factor];

        function isValid(arr){
            if((new Set(arr)).size != size) success = false;
        }
    }

    function clear(){
        outputMessageElement.textContent = '';
        tableElement.style.border = 'none';
        Array.from(tableBodyElement.querySelectorAll('input'))
            .forEach(input => input.value = '');
    }
}