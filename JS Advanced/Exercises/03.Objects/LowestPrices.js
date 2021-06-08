function LowestPrices(arr){
    let productList = new Set();
    let stocks = Object.values(arr.reduce(ParseProduct, {}))
                        .sort((pA, pB) => pA.price - pB.price);
    productList.forEach((elem) => {
                    let product = stocks.find(({productName}) => productName == elem);
                    console.log(`${product.productName} -> ${product.price} (${product.city})`)
                }
            );

    function ParseProduct(obj, line){
        let [city, productName, price] = line.split(' | ');
        obj[city + ':' + productName] = {city, productName, price: Number(price)};
        productList.add(productName);
        return obj;
    }
}

LowestPrices(
    ['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
)

LowestPrices(
    ['Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Sofia City | Mitsubishi | 10000',
    'Sofia City | Mercedes | 10000',
    'Sofia City | NoOffenseToCarLovers | 0',
    'Mexico City | Audi | 1000',
    'Mexico City | BMW | 99999',
    'New York City | Mitsubishi | 10000',
    'New York City | Mitsubishi | 1000',
    'Mexico City | Audi | 100000',
    'Washington City | Mercedes | 1000'])