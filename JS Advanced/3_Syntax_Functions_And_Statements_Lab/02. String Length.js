function solve(first, second, thrird){
    let stringLength = first.length + second.length + thrird.length;
    let averageLength = Math.floor(stringLength / 3);
    console.log(stringLength);
    console.log(averageLength);
}

solve('chocolate', 'ice cream', 'cake');
solve('pasta', '5', '22.3');