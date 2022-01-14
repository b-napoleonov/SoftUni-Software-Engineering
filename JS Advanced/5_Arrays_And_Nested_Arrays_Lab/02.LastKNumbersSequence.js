function lastKNumbers(n, k) {
    let result = [1];
    for (let i = 1; i < n; i++) {
        let currentSum = 0;

        for (let j = i - k; j <= i; j++) {
            let element = result[j];

            if (element !== undefined) {
                currentSum += element;
            }
        }
        result.push(currentSum);
    }
    return result;
}

console.log(lastKNumbers(6, 3));
console.log(lastKNumbers(8, 2));