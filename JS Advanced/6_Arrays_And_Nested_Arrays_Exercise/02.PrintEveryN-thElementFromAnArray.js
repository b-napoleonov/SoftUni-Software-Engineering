function everyNthElement(arr, n) {
    var result = [];
    for (var i = 0; i < arr.length; i += n) {
        result.push(arr[i]);
    }
    return result;
}

console.log(everyNthElement(['5', '20', '31', '4', '20'], 2));
console.log(everyNthElement(['dsa', 'asd', 'test', 'tset', '2'], 2));
console.log(everyNthElement(['1', '2','3', '4', '5'], 6));