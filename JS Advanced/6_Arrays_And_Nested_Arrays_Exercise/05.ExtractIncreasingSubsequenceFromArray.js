function biggestNumber(arr = []){
    let result = [];
    let max = Number.NEGATIVE_INFINITY;
    for (const element of arr) {
        if (element > max) {
            max = element;
            result.push(max);
        }
    }
    return result;
}

console.log(biggestNumber([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(biggestNumber([1, 2, 3, 4]));
console.log(biggestNumber([20, 3, 2, 15, 6, 1]));