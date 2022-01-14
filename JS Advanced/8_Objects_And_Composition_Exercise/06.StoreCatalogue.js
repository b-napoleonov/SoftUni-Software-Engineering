function storeCatalogue(arr){
    let list = [];
    for (const item of arr) {
        let [product, price] = item.split(' : ');
        price = Number(price);

        list.push({ product, price });
    }

    list = list.sort((a, b) => (a.product).localeCompare(b.product));
    let groupInitial = '';

    for (const item of list) {
        if(item.product[0] !== groupInitial) {
            groupInitial = item.product[0];
            console.log(item.product[0]);
        }
        console.log(`  ${item.product}: ${item.price}`);
    }
}

storeCatalogue(['Appricot : 20.4', 
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']);

storeCatalogue(['Banana : 2',
"Rubic's Cube : 5",
'Raspberry P : 4999',
'Rolex : 100000',
'Rollon : 10',
'Rali Car : 2000000',
'Pesho : 0.000001',
'Barrel : 10']
);