function JoinArray(arr, delim){
    console.log(arr.join(delim));
}

JoinArray(['One', 'Two', 'Three', 'Four', 'Five'], '-');
JoinArray(['How about no?', 'I','will', 'not', 'do', 'it!'], '_');

function PrintNthElements(arr, n){
    return arr.filter((x, i) => i % n == 0 );
}

PrintNthElements(['5', '20', '31', '4', '20'], 2);
PrintNthElements(['dsa','asd', 'test', 'tset'], 2);
PrintNthElements(['1', '2','3', '4', '5'], 1);
PrintNthElements(['1'], 6);
PrintNthElements(['1', '2','3', '4', '5'], 6);

function AddRemoveElements(elements){
    let num = 1;
    let result = [];

    elements.forEach(element => {
        if (element == 'add') {
            result.push(num);
        } else {
            result.pop();
        }
        num++;
    });

    if(result.length == 0){
        console.log('Empty');
        return;
    }
    console.log(result.join('\n'))
}
 AddRemoveElements(['add', 'add', 'add', 'add']);
 AddRemoveElements(['add', 'add', 'remove', 'add', 'add']);
 AddRemoveElements(['remove', 'remove', 'remove']);

 function RotateArray(arr, count){
    idx = arr.length - count % arr.length;
    let result = [...arr.slice(idx), ...arr.slice(0,idx)];
    console.log(result.join(' '));
 }

 RotateArray(['1', '2', '3', '4'], 2);
 RotateArray(['Banana', 'Orange', 'Coconut', 'Apple'], 16);

 function IncreasingSubsequence(arr){
    let result = [];
    arr.reduce((biggest, curr) => doCheck(biggest, curr), arr[0]);
    return result;

    function doCheck(currBiggest, elem){
        if (elem >= currBiggest) {
            result.push(elem);
            currBiggest = elem;
        }
        return currBiggest;
    }
 }

 IncreasingSubsequence([1, 3, 8, 4, 10, 12, 3, 2, 24]);
 IncreasingSubsequence([20]);
 IncreasingSubsequence([-1, -2, 15, 8, -10, 24, 28, 27, 36]);

function ListOfNames(arr){
    console.log(arr.sort((a, b) => a.localeCompare(b))
                    .map((x, i) => `${i + 1}.${x}`)
                    .join('\n')
                );
}
ListOfNames(["John", "Bob", "Christina", "Ema", "chris"]);

function SortingNumbers(numbers){
    numbers.sort((a, b) => a - b);
    let result = [];
    let start = true;

    while (numbers.length > 0) {
        if (start) {
            result.push(numbers.shift());
        }else {
            result.push(numbers.pop());
        }
        start = !start;
    }

    return result;
}
function SortingNumbersNew(numbers){
    numbers.sort((a, b) => a - b);
    let result = [];
    let size = numbers.length;

    for (let i = 0, j = size - 1; i < j; i++, j--) {
        result.push(numbers[i]);
        result.push(numbers[j]);
    }
    
    if (size % 2 > 0) {
        result.push(numbers[(size - 1) / 2]);
    }

    return result;
}

SortingNumbersNew([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);
SortingNumbersNew([1]);
SortingNumbersNew([1, 3]);
SortingNumbersNew([3, 1]);
SortingNumbersNew([1, 3, 4]);

function SortByTwoCriteria(arr){
    arr.sort((a,b) =>{
        let diff = a.length - b.length;
        if (diff == 0) {
            return  a.localeCompare(b);
        }
        return diff;
    } );
    console.log(arr.join('\n'));
}
function SortByTwoCriteria(arr){
    arr.sort((a,b) => a.localeCompare(b));
    arr.sort((a,b) => a.length - b.length)
    console.log(arr.join('\n'));
}
SortByTwoCriteria(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);
SortByTwoCriteria(['test', 'Deny', 'omen', 'Default']);
SortByTwoCriteria(['alpha', 'betb', 'beta', 'gamma']);

function MagicMatrices(matr){
    let sum = matr[0].reduce((p, c) => p + c, 0);
    let colSum = [...matr[0]];

    for (let i = 1; i < matr.length; i++) {
        if(matr[i].reduce((p, c) => p + c, 0) != sum){
            console.log(false);
            return;
        }
        
        for (let j = 0; j < matr[0].length; j++) {
            colSum[j] += matr[i][j];
        }
    }
    console.log(colSum.every(n => n == sum));
}

MagicMatrices([ [4, 5, 6],
                [6, 5, 4],
                [5, 5, 5]]);

MagicMatrices([ [11, 32, 45],
                [21, 0, 1],
                [21, 1, 1]]);

MagicMatrices([ [1, 0, 0],
                [0, 0, 1],
                [0, 1, 0]]);
    
function TicTacToe(moves){
    let matr = [[false, false, false],[false, false, false],[false, false, false]];
    let signs = {true: 'X', false: 'O'}; 
    let free = 9;
    let winner = '';
    moves = moves.map(m => [Number(m[0]), Number(m[2])]);
    let firstPlayer = true;

    for (let i = 0; i < moves.length; i++) {
        if (free == 0) {
            break;
        }    
        if(Play(moves[i][0], moves[i][1])){
            break;
        }
    
    }
    if(!winner){
        console.log('The game ended! Nobody wins :(');
    }else{
        console.log(`Player ${winner} wins!`);
    }
    PrintMatrix();

    function Play(r, c){
        let sign = signs[firstPlayer];

        if(matr[r][c] != false){
            console.log('This place is already taken. Please choose another!');
            return false;
        }else{
            matr[r][c] = sign;
            free--;
            firstPlayer = !firstPlayer;
            if(IsWinner(r, c)){
                winner = sign;
                return true;
            }
        }

        function IsWinner(r, c){
            return  matr[r].every(s => s == sign) ||
                    [matr[0][c], matr[1][c], matr[2][c]].every(s => s == sign)||
                    [matr[0][0], matr[1][1], matr[2][2]].every(s => s == sign)||
                    [matr[0][2], matr[1][1], matr[2][0]].every(s => s == sign);
        }

    }
    function PrintMatrix(){
        matr.forEach(row => console.log(row.join('\t')));
    }
}

TicTacToe(["0 1",
"0 0",
"0 2",
"2 0",
"1 0",
"1 2",
"1 1",
"2 1",
"2 2",
"0 0"]);

function DiagonalAttack(matrixOfStrings){
    let matr = matrixOfStrings.map(s => s.split(' ').map(Number));
    let sumR = 0;
    let sumL = 0;
    let size = matr.length;

    for (let i = 0, j = size - 1; i < size; i++, j--) {
        sumR += matr[i][i];
        sumL += matr[j][i];
    }
    if(sumL == sumR){
        let result = [];
        for (let k = 0; k < size; k++) {
            result.push(Array(size).fill(sumL));
        }
        for (let i = 0, j = size - 1; i < size; i++, j--) {
            result[i][i] = matr[i][i];
            result[j][i] = matr[j][i];
        }
        matr = result;
    }

    matr.forEach(row => console.log(row.join(' ')));
}

DiagonalAttack(['5 3 12 3 1',
                '11 4 23 2 5',
                '101 12 3 21 10',
                '1 4 5 2 2',
                '5 22 33 11 1']);
                
function Orbit([width, height, x, y]){

}

Orbit([4, 4, 0, 0]);




console.log('end')