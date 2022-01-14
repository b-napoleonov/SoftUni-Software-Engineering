function oddNumbers(arr){
    let result = [];
    for (let i = 0; i < arr.length; i++) {
        if (i % 2 !== 0) {
            result.unshift(arr[i] * 2);
        }
    }

    return result.join(' ');
}

console.log(oddNumbers([10, 15, 20, 25]));
console.log(oddNumbers([3, 0, 10, 4, 7, 3]));