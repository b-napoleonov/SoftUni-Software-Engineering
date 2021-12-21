function aggregate(arr){
    let sum = arr.reduce((a, b) => a + b);
    let sumInverse = arr.reduce((a, b) => a + 1 / b, 0);
    let concat = arr.reduce((a, b) => a + b.toString());

    console.log(sum);
    console.log(sumInverse);
    console.log(concat);
}

aggregate([1, 2, 3]);
aggregate([2, 4, 8, 16]);