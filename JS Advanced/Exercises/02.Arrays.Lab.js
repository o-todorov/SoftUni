function LastKNumbersSequence(n, k){
    let result = [1];
    for (let i = 0; i < n - 1; i++) {
        result.push((result.slice(-k).reduce((p, c) => p + c, 0)));
    }
    return result;
}

LastKNumbersSequence(8, 2);

function BiggerHalf(arr){
    let start = Math.trunc(arr.length / 2);
    return arr.sort((a, b) => a - b).slice(start);
}
BiggerHalf([4, 7, 2, 5]);
BiggerHalf([3, 19, 14, 7, 2, 19, 6]);
BiggerHalf([3, 19, 14]);
BiggerHalf([3]);

function PieceOfPie(arr, startStr, endStr){
    //console.log( arr.slice(arr.indexOf(startStr), arr.indexOf(endStr) + 1));
    return arr.slice(arr.indexOf(startStr), arr.indexOf(endStr) + 1);
}
PieceOfPie(["Apple Crisp", "Mississippi Mud Pie", "Pot Pie", "Steak and Cheese Pie", "Butter Chicken Pie", "Smoked Fish Pie"],
'Pot Pie',
'Smoked Fish Pie')

function ProcessOddPositions(inputArr){
    console.log(inputArr.reduce((retArr, c, i) => {if(i % 2 == 1)retArr.push(c * 2); return retArr}, [])
                        .reverse()
                        .join(' ')
                )
}
ProcessOddPositions([10, 15, 20, 25]);
ProcessOddPositions([3, 0, 10, 4, 7, 3]);


console.log('end');