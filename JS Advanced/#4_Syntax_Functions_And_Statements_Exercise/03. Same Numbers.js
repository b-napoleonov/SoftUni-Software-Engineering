function checkSame(number) {
    let arr = number.toString().split('');
    let result = true;
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] !== arr[0]) {
            result = false;
            break;
        }
    }

    let sum = arr.reduce(function(a, b) {
        return parseInt(a) + parseInt(b);});
    console.log(result);
    console.log(sum);
}

checkSame(2222222);
checkSame(1234);