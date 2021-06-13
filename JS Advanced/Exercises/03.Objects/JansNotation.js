function calc(input){
    let calculator = {
        '+': ([a, b]) => a + b,
        '*': ([a, b]) => a * b,
        '-': ([a, b]) => a - b,
        '/': ([a, b]) => a / b,

    }
    
    let memory = [];

    for (const data of input) {
        if(typeof(data) === 'number'){
            memory.push(data);
        }else{
            if(memory.length < 2){
                console.log('Error: not enough operands!');
                return;
            }
            let result = calculator[data](memory.slice(-2));
            memory.splice(-2, 2, result);
        }
    }
    if(memory.length > 1){
        console.log('Error: too many operands!')
    }else{
        console.log(memory[0]);
    }

}

calc(
    [5,
    3,
    4,
    '*',
    '-']
)
calc(
    [3,
        4,
        '+'])