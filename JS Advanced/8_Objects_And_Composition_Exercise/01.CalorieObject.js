function calorieObject(arr){
    let obj = {};

    arr.forEach((_, i) => {
       i % 2 === 0 ? obj[arr[i]] = Number(arr[i + 1]) : null; 
    });

    return obj;
}

console.log(calorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));
console.log(calorieObject(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']));