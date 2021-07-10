function attachEvents() {
    let forecastContainerTemplate   = document.querySelector('#forecast').cloneNode(true);
    let submitButton                = document.querySelector('#submit');
    submitButton.addEventListener('click', getWeather);
    submitButton.disabled = true;

    const baseURL = 'http://localhost:3030/jsonstore/forecaster';
    let locations;
    
    fetch(`${baseURL}/locations`)
        .then(body => body.json())
        .then(arr => {
            locations = arr.reduce((locs, x) => {
                locs[x.name] = x;
                return locs;
            }, {})

            submitButton.disabled = false;
        })

    function getWeather(){
        let locationName = document.querySelector('#location').value;
        if(!locations[locationName]){
            errorHandling();
            return;
        }
        
        let code = locations[locationName].code;
        document.querySelector('#forecast').replaceWith(forecastContainerTemplate.cloneNode(true));
        let forecastContainer = document.querySelector('#forecast');

        Promise.all([   fetch(`${baseURL}/today/${code}`),
                        fetch(`${baseURL}/upcoming/${code}`)    
                    ])

                .then(res => {
                    res[0].json()
                        .then(data => {
                            let infoNode = createInfoNode()['today'](data);
                            forecastContainer.querySelector('#current').append(infoNode);
                            forecastContainer.style.display = 'block';
                        })

                    res[1].json()
                        .then(data => {
                            let infoNode = createInfoNode()['upcoming'](data);
                            forecastContainer.querySelector('#upcoming').append(infoNode);
                            forecastContainer.style.display = 'block';
                        })
                })
                .catch(err =>{
                    errorHandling();
                })

        function createInfoNode(){
            let symb = {
                'Sunny':        '☀',
                'Partly sunny': '⛅',
                'Overcast':     '☁',
                'Rain':         '☂'
            }

            return {
                'today': ({name, forecast}) => {
                    let div = document.createElement('div');
                    div.classList.add('forecast');
                    div.appendChild(createSpan('symbol', `${symb[forecast.condition]}`));
                    let condition = div.appendChild(createSpan('condition'));
                    condition.appendChild(createSpan('forecast-data', name));
                    condition.appendChild(createSpan('forecast-data', `${forecast.low}°/${forecast.high}°`));
                    condition.appendChild(createSpan('forecast-data', forecast.condition));
                    return div;
                },
                'upcoming': ({forecast}) => {
                    let div = document.createElement('div');
                    div.classList.add('forecast-info');

                    forecast.forEach(({condition, low, high}) => {
                        let conditionElem = div.appendChild(createSpan('upcoming'));
                        conditionElem.appendChild(createSpan('symbol', `${symb[condition]}`));
                        conditionElem.appendChild(createSpan('forecast-data', `${low}°/${high}°`));
                        conditionElem.appendChild(createSpan('forecast-data', condition));
                        })
                    return div;
                },
            };

            function createSpan(clsName, txtContent){
                let span = document.createElement('span');
                span.classList.add(clsName);
                if(txtContent) span.textContent = txtContent;
                return span;
            }
        }
            
        function errorHandling(){
            let forecastContainer = document.querySelector('#forecast');
            forecastContainer.textContent = 'Error';
            forecastContainer.style.display = 'block';
        }

    }
}

attachEvents();