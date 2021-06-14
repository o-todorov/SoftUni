function sumTable() {
    let tablerows = document.querySelectorAll('table tr');
    let sum = 0;
    for (let i = 1; i < tablerows.length - 1; i++) {
        sum += Number(tablerows[i].lastChild.textContent);      
    }
    document.getElementById('sum').textContent = sum;
}