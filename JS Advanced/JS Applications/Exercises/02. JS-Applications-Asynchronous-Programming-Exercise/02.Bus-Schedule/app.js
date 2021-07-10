function solve() {
    let infoDiv = document.querySelector('#info');

    function depart() {
        fetch(`${baseURL}${currStop.next}`)
            .then(body => body.json())
            .then(stop => {
                currStop = stop;
                infoDiv.textContent = `Next stop ${currStop.name}`;
                toggleButtons();
            })
            .catch(err => {
                errorHandling();
                return;
            })
    }

    function arrive() {
        infoDiv.textContent = `Arriving at ${currStop.name}`;
        toggleButtons();
        // currStop.next = 45; //for error test only
    }

    function toggleButtons(){
        [...document.querySelectorAll('#controls input')]
            .forEach(b => b.disabled = !b.disabled);
    }

    function errorHandling(){
        infoDiv.textContent = 'Error';
        [...document.querySelectorAll('#controls input')]
            .forEach(b => b.disabled = true);
    }
    return {
        depart,
        arrive
    };
}

let currStop = {'next': 'depot'};
let baseURL = 'http://localhost:3030/jsonstore/bus/schedule/';

let result = solve();