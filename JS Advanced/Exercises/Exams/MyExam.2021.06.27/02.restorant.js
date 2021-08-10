class Restaurant{
    menu = {};
    stockProducts = {};
    history = [];
    constructor(budgetMoney){
        this.budgetMoney = budgetMoney;
    }

    loadProducts(products){ // array of strings
        let result = [];
        let action = '';
        products
            .map(x => x.split(' '))
            .map(([name, quantity, price]) => {return{name, quantity:Number(quantity), price:Number(price)}})
            .forEach(prod => {
                if(this.budgetMoney >= prod.price){
                    this.budgetMoney -=  prod.price;
                    if(this.stockProducts.hasOwnProperty(prod.name)){
                        prod.quantity += this.stockProducts[prod.name].quantity;
                    }
                    this.stockProducts[prod.name] = prod;
                    action = `Successfully loaded ${prod.quantity} ${prod.name}`;
                }else{
                    action = `There was not enough money to load ${prod.quantity} ${prod.name}`;
                }

                this.history.push(action);
                result.push(action);
            });
        
            return result.join('\n');
    }

    addToMenu(meal, productsNeeded, price){  //  - array of strings
        if(!this.menu.hasOwnProperty(meal)){
            let pr = productsNeeded.map(x=>x.split(' '))
                        .map(([name, quantity]) => {return{name, quantity: Number(quantity)};})
            this.menu[meal] = {name:meal, products: pr, price:Number(price)};
            let mealCount = Object.keys(this.menu).length;
            if(mealCount == 1){
                return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
            }else{
                return `Great idea! Now with the ${meal} we have ${mealCount} meals in the menu, other ideas?`;
            }
        }else{
            return `The ${meal} is already in the our menu, try something different.`;
        }

    }

    showTheMenu(){
        if(Object.keys(this.menu).length == 0){
            return 'Our menu is not ready yet, please come later...';
        }
        return [...Object.values(this.menu)]
                        .map(m => `${m.name} - $ ${m.price}`)
                        .join('\n');
    }

    makeTheOrder(meal){  // meal is string
        if(!this.menu.hasOwnProperty(meal)){
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }
        meal = this.menu[meal];
        let hasProducts = true;

        meal.products.forEach(p => {
            if(!this.stockProducts[p.name] || this.stockProducts[p.name].quantity < p.quantity){
                hasProducts = false;
            }
        })

        if(hasProducts){
            meal.products.forEach(p => this.stockProducts[p.name] -= p.quantity);
            this.budgetMoney += meal.price;
            return `Your order (${meal.name}) will be completed in the next 30 minutes and will cost you ${meal.price}.`;
        }else{
            return `For the time being, we cannot complete your order (${meal.name}), we are very sorry...`;
        }

    }
}
/*
let test = new Restaurant(1000);
test.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']);
test.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
let res = test.makeTheOrder('frozenYogurt');

let expected = 'Your order (frozenYogurt) will be completed in the next 30 minutes and will cost you 9.99.' */

/*
let test = new Restaurant(1000);
let res = test.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
console.log (res)
'Great idea! Now with the frozenYogurt we have 1 meal in the menu, other ideas?'  */

/*
let test = new Restaurant(1000);
test.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
let res = test.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55);
console.log (res)
"Great idea! Now with the Pizza we have 2 meals in the menu, other ideas?"   */
let kitchen = new Restaurant(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));

/*
let kitchen = new Restaurant(1000);
console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
'Great idea! Now with the frozenYogurt we have 1 meal on the menu, other ideas?'
'Great idea! Now with the Pizza we have 2 meals on the menu, other'  */