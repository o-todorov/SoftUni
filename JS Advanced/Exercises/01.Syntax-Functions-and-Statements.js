//  1.Fruit
function Solve(fruit, grams, pricePerKg){
    let kg = grams / 1000;
    let money = kg * pricePerKg;
    console.log(`I need \$${money.toFixed(2)} to buy ${kg.toFixed(2)} kilograms ${fruit}.`)
}

Solve('orange', 2500, 1.80);

//   2.Greatest Common Divisor - GCD
function SolveGCD(a, b){
    let smaller = Math.min(a, b);
    let bigger = Math.max(a, b); 
    
    for (let gcd = smaller; gcd >= 1; gcd--) {
        if (bigger % gcd == 0 && smaller % gcd == 0) {
            console.log(gcd);
            break;
        }
    }
}

SolveGCD(15, 5);
SolveGCD(2154, 458);

//   3.Same Numbers
function SolveEqualDigits(intNum){
    let strNum = intNum.toString();
    let sum = 0;
    let areEqual = true;
    let first = strNum[0]; 
    
    for (let i = 0; i < strNum.length; i++) {
        sum += Number(strNum[i]);

        if(strNum[i] != first){
            areEqual = false;
        }
    }

    console.log(areEqual.toString());
    console.log(sum);
}

SolveEqualDigits(15);
SolveEqualDigits(2222);

//   Time to Walk
function SolveTimeToWalk(steps, footprintLenght, speedKmPerHour){
    let dist = steps * footprintLenght / 1000;
    let timeInSeconds = Math.round(dist / speedKmPerHour * 3600);
    let breakTime = Math.trunc(dist / 0.5) * 60;
    timeInSeconds += breakTime;
    let hours = (Math.floor(timeInSeconds / 3600)).toString().padStart(2, '0');
    timeInSeconds =  timeInSeconds % 3600;
    let minutes = (Math.floor(timeInSeconds / 60)).toString().padStart(2, '0');
    let seconds = (timeInSeconds % 60).toString().padStart(2, '0');
    console.log(`${hours}:${minutes}:${seconds}`);
}
SolveTimeToWalk(4000, 0.60, 5);
SolveTimeToWalk(2564, 0.70, 5.5);

function SolveSpeedLimit(speed, area){
    let areas = {'motorway': 130,
                'interstate': 90,
                'city': 50,
                'residential': 20
    }

    let speedlimit = Number(areas[area]);
    let diff = speed - speedlimit;

    if (diff <= 0) {
        console.log(`Driving ${speed} km/h in a ${speedlimit} zone`)
    } else {
        let status='';
        if (diff <= 20) {
            status = 'speeding';
        }else if(diff <= 40){
            status = 'excessive speeding';
        }else{
            status = 'reckless driving';
        }
        console.log(`The speed is ${diff} km/h faster than the allowed speed of ${speedlimit} - ${status}`)
    }
}
SolveSpeedLimit(40, 'city');
SolveSpeedLimit(21, 'residential');
SolveSpeedLimit(120, 'interstate');
SolveSpeedLimit(200, 'motorway');

function SolveCookingNumbers(num, ...args){
    let base = Number(num);
    let operations = {
        'chop': (n) => n / 2,
        'dice': (n) => Math.sqrt(n, 2),
        'spice': (n) => n + 1,
        'bake': (n) => n * 3,
        'fillet': (n) => n * 0.8,
    }
    args.forEach((x) => {
        base = operations[x](base);
        console.log(base)});
}
SolveCookingNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop');
SolveCookingNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet');

function ValidityChecker(x1, y1, x2, y2){
    PrintValidity(x1, y1, 0, 0);
    PrintValidity(x2, y2, 0, 0);
    PrintValidity(x1, y1, x2, y2);

    function PrintValidity(x1, y1, x2, y2){
        let valid = 'is invalid';

        if (IsValid(x1, y1, x2, y2)) {
            valid = 'is valid';
        }

        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} ${valid}`);
    }
    function IsValid(x1, y1, x2, y2){
        let dist = Math.sqrt(GetPowred(x1, x2) + GetPowred(y1, y2));
        return Number.isInteger(dist);

        function GetPowred(a, b){
            return Math.pow(Math.abs(a - b), 2);
        }
    }
}
ValidityChecker(3, 0, 0, 4);
ValidityChecker(2, 1, 1, 1);

function WordsUppercase(input){
    let words = input.split(/\W+/)
                    .filter(x => x != '')
                    .map(x => x.toUpperCase());
    console.log(words.join(', '));
}
WordsUppercase('Hi, how are you?');

console.log('end');