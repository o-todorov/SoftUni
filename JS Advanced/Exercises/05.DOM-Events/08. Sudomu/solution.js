function solve() {
    let buttons = document.querySelectorAll('#exercise button');
    buttons[0].addEventListener('click', check);
    buttons[1].addEventListener('click', clear);
    let matrix = Array.from(document.querySelectorAll('#exercise tbody tr'))
                        .map(r => Array.from(r.children)
                            .map(td => td.children[0]));

    let tableElement            = document.querySelector('#exercise table');
    let outputMessageElement    = document.querySelector('#check p');

    const borderstyles  = {winner: '2px solid green', looser: '2px solid red'}
    const colors        = {winner: 'green', looser: 'red'}
    const messages      = {winner: 'You solve it! Congratulations!', looser: 'NOP! You are not done yet...'}
    
    function check(){
        let matrixValues    = matrix.map(r =>  r.map(input => input.value));
        let size            = matrixValues.length;
        let success         = true;

        matrixValues.forEach(isValid);

        if(success){
            let tempMatr = Array.from({length: size}, () => []);

            for (let i = 0; i < size; i++) {
                for (let j = 0; j < size; j++) {
                    tempMatr[j][i] = matrixValues[i][j];                 
                }              
            }

            tempMatr.forEach(isValid);
        }


        let factor = success?'winner':'looser';
        tableElement.style.border               = borderstyles[factor];
        outputMessageElement.style.color        = colors[factor];
        outputMessageElement.textContent        = messages[factor];

        function isValid(arr){
            let set = new Set(arr);
            if(set.size != size) success = false;
        }
    }

    function clear(){
        outputMessageElement.textContent = '';
        tableElement.style.border = 'none';
        matrix.forEach(r => r.forEach(input => input.value = ''));
    }
}