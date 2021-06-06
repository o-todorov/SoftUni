function CarFactory({model, power, color, carriage, wheelsize}){
    let car = {model};
    let[pw, vol] = [[90,1800],[120, 2400],[200, 3500]].find(([p, v]) => p >= power);
    car.engine = {power: pw, volume: vol};
    car.carriage = {type:carriage, color};
    car.wheels = Array(4).fill(wheelsize % 2 == 1?wheelsize:wheelsize - 1);
    return car;
}

console.log(
CarFactory(
    { 
        model: 'VW Golf II',
        power: 90,
        color: 'blue',
        carriage: 'hatchback',
        wheelsize: 14 
    }
));

let car = CarFactory(
{ model: 'Opel Vectra',
  power: 110,
  color: 'grey',
  carriage: 'coupe',
  wheelsize: 17 }
)
console.log(car);