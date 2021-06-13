function Solve(strArr){
    let table = strArr.reduce((a, row) => {
        a.push(row.split(/\s*\|\s*/).filter(x => x));
        return a;
    }, []);

    let heads = table.shift();

    console.log(
        JSON.stringify(
            table.reduce((a, row,) => {
                a.push(
                    row.reduce((obj, data, i) => {
                        if(i == 0){
                            obj[heads[i]] = data;
                        }else{
                            obj[heads[i]] = Math.round(data * 100) / 100;
                        }
                        return obj;
                    }, {})
                )
                return a;
            }, [])
        )
    )
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