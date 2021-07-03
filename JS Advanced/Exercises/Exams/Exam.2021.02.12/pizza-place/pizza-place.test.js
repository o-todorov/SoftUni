const pizzUni = require('./pizza-place');
const {expect, assert} = require('chai');

describe("Tests for pizza place", () => {
    describe("Tests for making an order", () =>{

        it("Should return correct confirmation message when order a pizza", () => {
            let pizzaName = 'Caltsone';
            let retval = pizzUni.makeAnOrder({orderedPizza: pizzaName});

            expect(retval).to.equal(`You just ordered ${pizzaName}`);
        });

        it("Should return correct confirmation message when order pizza and drink", () => {
            let pizzaName = 'Caltsone';
            let drinkName = 'Fanta';
            let retval = pizzUni.makeAnOrder({orderedPizza: pizzaName, orderedDrink: drinkName});

            expect(retval).to.be.equal(`You just ordered ${pizzaName} and ${drinkName}.`);
        });

        it("Should throw when order a drink only or nothing", () => {
            let drinkName = 'Cola';
            expect(() => pizzUni.makeAnOrder({orderedDrink: drinkName})).to.throw();
            expect(pizzUni.makeAnOrder.bind(null, {})).to.throw();
        });
     });
    describe("Tests for getRemainingWork function", () =>{
        let ordersList = [  {pizzaName: 'Peperone', status: 'ready'},
                            {pizzaName: 'Sicilia', status: 'preparing'},
                            {pizzaName: 'Calcone', status: 'preparing'}];
        it("Should return correct remaining pizzas list", () => {
            let retval = pizzUni.getRemainingWork(ordersList);
            let expectedPizzas = 'Sicilia, Calcone';

            expect(retval).to.equal(`The following pizzas are still preparing: ${expectedPizzas}.`);
        });

        it("Should return correct complete message when no orders left or empty list is delivered", () => {
            let retval = pizzUni.getRemainingWork(ordersList.slice(0,1));
            let expected = 'All orders are complete!';

            expect(retval).to.be.equal(expected);

            retval = pizzUni.getRemainingWork([]);
            expect(retval).to.be.equal(expected);
        });

     });
    describe("Tests for orderType function", () =>{
        it("Should return correct total sum according the type of the order", () => {
            let totalSum = 10;
            let typeOfOrder = 'Carry Out'
            expect(pizzUni.orderType(totalSum, typeOfOrder)).to.equal(9);
            typeOfOrder = 'Delivery'
            expect(pizzUni.orderType(totalSum, typeOfOrder)).to.equal(totalSum);
            totalSum = 10.5;
            typeOfOrder = 'Carry Out'
            expect(pizzUni.orderType(totalSum, typeOfOrder)).to.equal(9.45);
        });

     });

});