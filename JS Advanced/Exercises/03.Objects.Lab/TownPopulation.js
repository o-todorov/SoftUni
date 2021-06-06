function CreateCityRegistry(input){
    let result = {};
    input.map(x => x.split(' <-> ')).map(([x, y]) => [x, Number(y)]).forEach(([city, population]) => {
        if(result[city]){
             population += result[city];
        }
        result[city] = population;
    });

    Object.entries(result).forEach(([city, population]) => 
        console.log(`${city} : ${population}`))
}

CreateCityRegistry(
    [
        'Istanbul <-> 100000',
        'Honk Kong <-> 2100004',
        'Jerusalem <-> 2352344',
        'Mexico City <-> 23401925',
        'Istanbul <-> 1000'    ]
)