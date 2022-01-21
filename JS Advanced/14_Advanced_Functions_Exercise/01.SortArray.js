function sortArray(arr, condition) {
    switch (condition) {
        case 'asc':
            arr.sort((a, b) => {
                return a - b;
            });
            break;
    
        case 'desc':
            arr.sort((a, b) => b - a);
            break;
    }

    return arr;
}

console.log(sortArray([14, 7, 17, 6, 8], 'asc'));
console.log(sortArray([14, 7, 17, 6, 8], 'desc'));