class ChristmasDinner{
    constructor(budget){
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    get budget(){
        return this._budget;
    }

    set budget(budget){
        if(budget < 0){
            throw new Error('The budget cannot be a negative number');
        }

        this._budget = budget;
    }

    shopping(prodArr){
        let [product, price] = prodArr;

        if(price > this.budget){
            throw new Error('Not enough money to buy this product.');
        }

        this.budget -= price;
        this.products.push(product);
        return `You have successfully bought ${product}!`;
    }

    recipes({ recipeName, productsList }){
        let cook = true;

        for (let product of productsList) {
            if(!this.products.includes(product)){
                cook = false;
                break;
            }
        }

        if (cook){
            this.dishes.push({recipeName, productsList});
            return `${recipeName} has been successfully cooked!`;
        }

        throw new Error('We do not have this product');
    }

    inviteGuests(name, dish){
        if (this.dishes.some(d => d.recipeName === dish) === false) {
            throw new Error('We do not have this dish');
        }

        if (this.guests[name]) {
            throw new Error('This guest has already been invited');
        }

        this.guests[name] = dish;

        return `You have successfully invited ${name}!`;
    }

    showAttendance(){
        let result = [];

        Object.entries(this.guests).forEach(([name, dish]) => {
            let prod = this.dishes.find(d => d.recipeName == dish);
            result.push(`${name} will eat ${dish}, which consists of ${prod.productsList.join(', ')}`);
        });

        return result.join('\n');
    }
}

let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());