function evenPositions(arr) {
    let result = '';
    for (let i = 0; i < arr.length; i += 2) {
        result += arr[i] + " ";
    }
    console.log(result);
}

evenPositions(['20', '30', '40', '50', '60']);
evenPositions(['5', '10']);