function calculateMoney(fruit, weight, price) {
    let weightInKilograms = weight / 1000;
    let moneyNeeded = weightInKilograms * price;

    console.log(`I need $${moneyNeeded.toFixed(2)} to buy ${weightInKilograms.toFixed(2)} kilograms ${fruit}.`);
}

calculateMoney('orange', 2500, 1.80);
calculateMoney('apple', 1563, 2.35);