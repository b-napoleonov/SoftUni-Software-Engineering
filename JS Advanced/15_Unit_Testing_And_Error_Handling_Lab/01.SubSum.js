function arrSum(arr, start, end){
    if (typeof(arr) != typeof([])){
        return NaN;
    }

    if (start < 0){
        start = 0;
    }

    if (end >= arr.length){
        end = arr.length - 1;
    }

    let sum = 0;

    for (let i = start; i <= end; i++) {
        sum += Number(arr[i]);
    }

    return sum;
}

console.log(arrSum([10, 20, 30, 40, 50, 60], 3, 300));
console.log(arrSum([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(arrSum([10, 'twenty', 30, 40], 0, 2));
console.log(arrSum([], 1, 2));
console.log(arrSum('text', 0, 2));