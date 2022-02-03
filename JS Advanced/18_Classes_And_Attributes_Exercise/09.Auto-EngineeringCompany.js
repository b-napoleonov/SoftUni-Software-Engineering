function solve(inputArr){

    let cars = {};

    for (const input of inputArr) {
        let [carBrand, carModel, producedCars] = input.split(" | ");

        if (!cars.hasOwnProperty(carBrand)) {
            cars[carBrand] = [];
        }

        if (cars[carBrand].find(c => c.carModel === carModel) === undefined) {
            cars[carBrand].push({carModel, producedCars: Number(producedCars)});
        }
        else{
            let currentCar = cars[carBrand].find(c => c.carModel === carModel);
            currentCar.producedCars += Number(producedCars);
        }
    }

    for (const brand in cars) {
        console.log(`${brand}`);

        for (const kvp of cars[brand]) {
            console.log(`###${kvp.carModel} -> ${kvp.producedCars}`);
        }
    }
}

solve([
    //'Mercedes-Benz | 50PS | 123',
    'Mini | Clubman | 20000',
    //'Mini | Convertible | 1000',
    //'Mercedes-Benz | 60PS | 3000',
    //'Hyunday | Elantra GT | 20000',
    //'Mini | Countryman | 100',
    //'Mercedes-Benz | W210 | 100',
    'Mini | Clubman | 1000',
    'Mercedes-Benz | W163 | 200']);