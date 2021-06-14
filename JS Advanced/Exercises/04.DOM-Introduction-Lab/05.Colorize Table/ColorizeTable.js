function colorize() {
    let rowsToColor = document.querySelectorAll('table tr:nth-child(even)');
    for (const row of rowsToColor) {
        row.setAttribute('style', 'background-color:teal');
    }
}