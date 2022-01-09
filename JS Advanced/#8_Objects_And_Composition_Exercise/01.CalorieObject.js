function calorieObject(arr){
    let name = [];
    let calories = [];
    for (let i = 0; i < arr.length; i++) {
        if (i % 2 === 0) {
            name.push(arr[i]);
        }
        else {
            calories.push(arr[i]);
        }
    }

    let obj = {};
    for (let i = 0; i < name.length; i++) {
        obj[name[i]] = Number(calories[i]);
    }

    console.log(obj);
}

calorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
calorieObject(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);