function attachEventsListeners() {
    document.querySelector('#convert').addEventListener('click', convert);
    let rates = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.0254
    }

    function convert(){
        let inputUnit = document.querySelector('#inputUnits').value;
        let inputDist = Number(document.querySelector('#inputDistance').value);
        console.log(inputUnit);
        let outputUnit = document.querySelector('#outputUnits').value;
        let outputDistElement = document.querySelector('#outputDistance');
        console.log(outputUnit);
        let converted = inputDist * rates[inputUnit] / rates[outputUnit];
        outputDistElement.value = converted;
    }

}