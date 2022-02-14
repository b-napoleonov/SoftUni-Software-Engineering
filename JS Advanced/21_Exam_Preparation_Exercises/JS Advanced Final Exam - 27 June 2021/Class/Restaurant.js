//2 tests are wrong in judge.
class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = budgetMoney;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(productsArr) {
        for (const input of productsArr) {
            let [productName, productQuantity, productTotalPrice] = input.split(' ');

            if (productTotalPrice <= this.budgetMoney) {
                if (!this.stockProducts[productName]) {
                    this.stockProducts[productName] = {
                        quantity: 0,
                    }

                    this.stockProducts[productName].quantity += Number(productQuantity);
                }

                this.budgetMoney -= Number(productTotalPrice);
                this.history.push(`Successfully loaded ${productQuantity} ${productName}`);
            }
            else {
                this.history.push(`There was not enough money to load ${productQuantity} ${productName}`)
            }
        }

        return this.history.join('\n');
    }

    addToMenu(meal, neededProducts, price) {
        if (!this.menu[meal]) {
            this.menu[meal] = {
                products: {},
                price: price
            }

            for (const product of neededProducts) {
                let [productName, productQuantity] = product.split(' ');

                if (!this.menu[meal].products[productName]) {
                    this.menu[meal].products[productName] = 0;
                }

                this.menu[meal].products[productName] += Number(productQuantity);
            }

            if (Object.keys(this.menu).length === 1) {
                return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`
            }
            else if (Object.keys(this.menu).length === 0 || Object.keys(this.menu).length > 1) {
                return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`
            }
        }
        else {
            return `The ${meal} is already in the our menu, try something different.`
        }
    }

    showTheMenu() {
        let result = [];

        Object.entries(this.menu).forEach(([key, value]) => {
            result.push(`${key} - $ ${value.price}`);
        });

        return result.join('\n');
    }

    makeTheOrder(meal) {
        let orderedMeal = this.menu[meal];

        if (orderedMeal === undefined) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`
        }

        let orderedProducts = Object.entries(orderedMeal.products);

        for (const product of orderedProducts) {
            let [productName, productQuantity] = product;

            if (this.stockProducts[productName] === undefined || this.stockProducts[productName].quantity < productQuantity) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`
            }
        }

        for (const product of orderedProducts) {
            let [productName, productQuantity] = product;

            this.stockProducts[productName].quantity -= productQuantity;
        }

        this.budgetMoney += orderedMeal.price;
        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${orderedMeal.price}.`
    }
}
// let kitchen = new Restaurant(1000);
// console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));

let kitchen = new Restaurant(1000);
// console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
// console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));

//let kitchen = new Restaurant(1000);
//console.log(kitchen.showTheMenu());

kitchen.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']);
kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
console.log(kitchen.makeTheOrder('frozenYogurt'));
