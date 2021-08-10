class Parking{

    constructor(capacity){
        this.capacity = Number(capacity);
        this.vehicles = [];
    }
    addCar(carModel, carNumber){
        if(this.vehicles.length >= this.capacity){
            throw new Error('Not enough parking space.');
        }

        this.vehicles.push({carNumber, carModel, payed: false, toString: this.carToString});
        return `The ${carModel}, with a registration number ${carNumber}, parked.`
    }
    removeCar(carNumber){
        let found = this.vehicles.findIndex(c => c.carNumber == carNumber);

        if(found == -1){
            throw `The car, you're looking for, is not found.`;
        }
        if(!this.vehicles[found].payed){
            return(`${carNumber} needs to pay before leaving the parking lot.`);
        }else{
            this.vehicles = this.vehicles.filter(c => c.carNumber != carNumber);
            return `${carNumber} left the parking lot.`
        }
    }
    pay(carNumber){
        let found = this.vehicles.find(c => c.carNumber == carNumber);

        if(!found){
            throw `${carNumber} is not in the parking lot.`;
        }

        if(found.payed){
            throw `${carNumber}'s driver has already payed his ticket.`;
        }

        found.payed = true;
        return(`${carNumber}'s driver successfully payed for his stay.`);
    }
    getStatistics(carNumber){
        if(carNumber){
            return this.vehicles.find(c => c.carNumber == carNumber).toString();
        }else{
            return [`The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.`]
                    .concat([...this.vehicles]
                                        .sort((carA, carB) => carA.carModel.localeCompare(carB.carModel))
                                        .map(c => c.toString())
                    )
                    .join('\n');
        }
    }

    carToString() {
        return `${this.carModel} == ${this.carNumber} - ${this.payed?'Has payed':'Not payed'}`;
    }
}


try{
const parking = new Parking(12);

console.log(parking.addCar("volvo t600", "TX3691CA"));
console.log(parking.addCar("volvo t600", "TX3691CB"));
console.log(parking.addCar("volvo t600", "TX3691CC"));

console.log(parking.getStatistics());

console.log(parking.pay("TX3691CA"));
console.log(parking.pay("TX3691CB"));
console.log(parking.getStatistics("TX3691CA"));
console.log(parking.removeCar("TX3691CA"));
console.log(parking.getStatistics());
console.log("end");
}catch(e){
    console.log(e);
}