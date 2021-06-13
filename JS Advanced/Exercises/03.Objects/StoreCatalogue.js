function StoreCatalogue(arrStr){
    arrStr.map(ParseStockToObject)
            .sort((A, B) => A.name.localeCompare(B.name))
            .reduce((a, {name, price}) => {
                if(name[0] != a){
                    a = name[0];
                    console.log(a);
                }
                console.log(`${name}: ${price}`);
                return a;
            }, '-');

    function ParseStockToObject(line){
        let[name, price] = line.split(' : ');
        return {name, price: Number(price)};
    }
}

StoreCatalogue(
['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
)

StoreCatalogue(
    ['Banana : 2',
    'Rubic\'s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']
    
)