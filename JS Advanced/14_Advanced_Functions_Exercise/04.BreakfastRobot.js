function solution() {

    let recipes = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 }
    };

    let storage = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    return function manager(input) {

        let [command, item, quantity] = input.split(' ');

        switch (command) {
            case 'restock':
                return restock(item, quantity);

            case 'prepare':
                return prepare(item, quantity);

            case 'report':
                return report();
                
        }
    }

    function restock(item, quantity) {
        storage[item] += Number(quantity);
        return 'Success';
    }

    function prepare(recipe, quantity) {
        let flag = true;
        
        for (const element in recipes[recipe]) {
            if (storage[element] - recipes[recipe][element] * Number(quantity) < 0) {
                flag = false;
                return `Error: not enough ${element} in stock`
            }
        }

        if (flag) {
            for (const element in recipes[recipe]) {
                storage[element] -= recipes[recipe][element] * Number(quantity);
            }

            return `Success`;
        }
    }

    function report() {
        return `protein=${storage.protein} carbohydrate=${storage.carbohydrate} fat=${storage.fat} flavour=${storage.flavour}`;
    }
}

let manager = solution (); 
console.log (manager ("restock flavour 50")); // Success 
console.log (manager ("prepare lemonade 4")); // Error: not enough carbohydrate in stock 
