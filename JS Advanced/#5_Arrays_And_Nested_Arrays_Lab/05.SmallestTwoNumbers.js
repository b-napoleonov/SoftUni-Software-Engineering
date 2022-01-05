function smallestNumbers(arr){
    let first = Number.MAX_SAFE_INTEGER;
    let second = Number.MAX_SAFE_INTEGER;

    for (let i = 0; i < arr.length; i++) {
        let current = arr[i];

        if (current < first) {
            second = first;
            first = current;
        }
        else if (current < second) {
            second = current;
        }
    }

    console.log(first + ' ' + second);
}

smallestNumbers([30, 15, 50, 5]);
smallestNumbers([3, 0, 10, 4, 7, 3]);