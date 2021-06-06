function createAssemblyLine(){
    let library = {
        hasClima:function(car){
            car.temp = 21,
            car.tempSettings = 21,
            car.adjustTemp = function(){
                if(car.temp < car.tempSettings){
                    car.temp ++;
                }else if(car.temp > car.tempSettings)
                    car.temp --;
            }
        },
        hasAudio:function(car){
            car.currentTrack = {name: null, artist: null};
            car.currentTrack = null;
            car.nowPlaying = function(){
                if(car.currentTrack == null) return;
                console.log(`Now playing '${car.currentTrack.name}' by ${car.currentTrack.artist}`)
            }
        },
        hasParktronic:function(car){
            car.checkDistance = (distance)=> {
                let beep = '';
                if(distance < 0.1){
                    beep = 'Beep! Beep! Beep!';
                }else if(distance < 0.25){
                    beep = 'Beep! Beep!';
                }else if(distance < 0.5){
                    beep = 'Beep!';
                }
                console.log(beep);
            }
        },
    };


    return library;
}

const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};

assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);

assemblyLine.hasAudio(myCar);
myCar.currentTrack = {
    name: 'Never Gonna Give You Up',
    artist: 'Rick Astley'
};
myCar.nowPlaying();

assemblyLine.hasParktronic(myCar);
myCar.checkDistance(0.4);
myCar.checkDistance(0.2);

console.log(myCar);