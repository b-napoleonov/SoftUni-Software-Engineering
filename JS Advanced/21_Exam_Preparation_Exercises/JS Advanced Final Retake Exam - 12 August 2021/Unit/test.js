function cinema (projectionType) {

    const schedule = {
        "Premiere": 12.00,
        "Normal": 7.50,
        "Discount": 5.50
    }
    if (schedule.hasOwnProperty(projectionType)) {
        let price = schedule[projectionType];
        return price;
    } else {
        throw new Error('Invalid projection type.')
    }

}

console.log(cinema('Premiere'));
console.log(cinema('Normal'));
console.log(cinema('Discount'));
console.log(cinema('VIP'));