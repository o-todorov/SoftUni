function subtract() {
    const result = getnum('firstNumber') - getnum('secondNumber');
    document.getElementById('result').textContent = result;

    function getnum(id){
        return Number(document.getElementById(id).value);
    }
}