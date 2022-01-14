function magicMatrices(matrix){
    let neededSum = matrix[0].reduce((x, y) => x + y);
    let colSum = 0;
    for (let i = 0; i < matrix.length; i++) {
        let rowSum = matrix[i].reduce((x, y) => x + y);

        if (rowSum !== neededSum) {
            console.log('false');
            return;
        }
    }

    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix.length; j++) {
            colSum += matrix[j][i];
        }

        if (colSum !== neededSum) {
            console.log('false');
            return;
        }
        colSum = 0;
    }

    console.log('true');
}

magicMatrices(
    [[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]);

magicMatrices(
    [[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
   );

magicMatrices(
    [[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
   );