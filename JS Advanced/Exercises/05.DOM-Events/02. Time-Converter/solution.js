function attachEventsListeners() {
    let buttons = Array.from(document.querySelectorAll('input[type="button"]'));
    buttons.forEach(b => b.addEventListener('click', onclick));
    let scales = {'days': 3600 * 24, 'hours': 3600, 'minutes': 60, 'seconds': 1};


    function onclick(event){
        let button = event.currentTarget;
        let scaleKey = button.getAttribute('id').slice(0, -3);
        let seconds = Number(document.getElementById(scaleKey).value) * scales[scaleKey];
        
        [...Object.entries(scales)].forEach(([format, scale]) => {
            let value = seconds / scale;
            value = Math.round(value * 100) / 100;
            document.getElementById(format).value = value;
        })
    }
}