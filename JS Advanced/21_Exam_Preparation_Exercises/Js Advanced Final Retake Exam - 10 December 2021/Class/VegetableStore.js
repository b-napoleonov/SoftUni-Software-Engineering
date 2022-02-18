class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }

    loadingVegetables(vegetables) {
        const vegetableType = new Set();

        for (const vegetable of vegetables) {

            let [type, quantity, price] = vegetable.split(' ');

            if (this.availableProducts.some(x => x.type === type)) {
                let product = this.availableProducts.find(x => x.type === type);
                product.quantity += Number(quantity);

                if (product.price < Number(price)) {
                    product.price = Number(price);
                }
            }
            else {
                this.availableProducts.push({
                    type: type,
                    quantity: Number(quantity),
                    price: Number(price)
                });
            }


            vegetableType.add(type);
        }

        return `Successfully added ${Array.from(vegetableType).join(', ')}`;
    }

    buyingVegetables(selectedProducts){
        let totalPrice = 0;

        for (const product of selectedProducts) {
            let [type, quantity] = product.split(' ');
            let price = 0;
            let availableProduct = this.availableProducts.find(x => x.type === type);

            if (availableProduct === undefined) {
                throw new Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            }

            if (availableProduct.quantity < Number(quantity)) {
                throw new Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            }

            price = availableProduct.price * Number(quantity);
            availableProduct.quantity -= Number(quantity);
            totalPrice += price;
        }

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`
    }

    rottingVegetable(type, quantity){
        let product = this.availableProducts.find(x => x.type === type);

        if (product === undefined) {
            throw new Error(`${type} is not available in the store.`);
        }

        if (quantity > product.quantity) {
            product.quantity = 0;
            return `The entire quantity of the ${type} has been removed.`;
        }

        product.quantity -= Number(quantity);
        return `Some quantity of the ${type} has been removed.`;
    }

    revision(){
        let result = ['Available vegetables:'];
        this.availableProducts.sort((a, b) => a.price - b.price).forEach(x => result.push(`${x.type}-${x.quantity}-$${x.price.toFixed(1)}`));
        result.push(`The owner of the store is ${this.owner}, and the location is ${this.location}.`);

        return result.join('\n');
    }
}

let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
console.log(vegStore.rottingVegetable("Okra", 1));
console.log(vegStore.rottingVegetable("Okra", 2.5));
console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
console.log(vegStore.revision());