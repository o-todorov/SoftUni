function getInfo() {
    let showError = () => stopNameElem.textContent = 'Error';
    let busesListElem   = document.querySelector('#buses');
    let stopNameElem    = document.querySelector('#stopName');   
    let busStopID       = document.querySelector('#stopId').value;   
         
    while(busesListElem.firstChild) busesListElem.removeChild(busesListElem.firstChild);  
    
    if(!busStopID){
        showError();
        return;
    }     

    const baseURL = 'http://localhost:3030/jsonstore';
    const stopInfoPath = `${baseURL}/bus/businfo/${busStopID}`;

    fetch(stopInfoPath)
        .then(res => res.json())
        .then(stop => {
            stopNameElem.textContent = stop.name;
            Array.from(Object.entries(stop.buses))
                .map(([busNum, arrivalTime]) => `Bus ${busNum} arrives in ${arrivalTime}`)
                .forEach(t => busesListElem.appendChild(document.createElement('li')).textContent = t);
        })
        .catch(err => showError());
} 