function biggestElements(matrix){
    let biggest = matrix[0][0];
    for (let row of matrix) {
        if (Math.max(...row) > biggest) {
            biggest = Math.max(...row);
        } 
    }

    return biggest;
}

console.log(biggestElements([[20, 50, 10], [8, 33, 145]]));
console.log(biggestElements([[3, 5, 7, 12], [-1, 4, 33, 2], [8, 3, 0, 4]]));