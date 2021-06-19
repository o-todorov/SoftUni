function generateReport() {
    let heads = Array.from(document.querySelectorAll('table thead th input'))
                    .map((x, i) => [x.getAttribute('name'), i, x.checked])
                    .filter(x => x[2])
                    .reduce((obj, [name, index]) => {
                        obj[name] = index;
                        return obj;
                    }, {});

    let employeesRows = Array.from(document.querySelectorAll('table tbody tr'))
                                .map(row => Array.from(row.children)
                                                .map(cell => cell.innerText)
                                );
    let result = [];

    for (const employee of employeesRows) {
        let obj = {};
        for (const propName in heads) {
            obj[propName] = employee[heads[propName]];
        }
        result.push(obj);
    }
    
    if(Object.entries(heads).length > 0){
        document.querySelector('#output').textContent = JSON.stringify(result);
    }
}