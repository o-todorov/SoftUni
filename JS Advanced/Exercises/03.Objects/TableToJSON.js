function Solve(strArr){
    let table = strArr.map(row => row.split(/\s*\|\s*/).filter(x => x));

    let heads = table.shift();

    return JSON.stringify(table.map(makeCityObj));

    function makeCityObj(row){
            return row.reduce((city, data, i) => {
                city[heads[i]] = (i == 0? data:Math.round(Number(data) * 100) / 100);
                return city;
             }, {});
        }
}

Solve(
    ['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
    )

Solve(
    ['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |']
    )