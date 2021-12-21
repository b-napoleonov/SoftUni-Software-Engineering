function starSquare(n) {
    for (let i = 0; i < n; i++) {
        let line = "";
        for (let j = 0; j < n; j++) {
            line += "* ";
        }
        console.log(line);
    }
}

starSquare(1);
console.log();
starSquare(2);
console.log();
starSquare(5);
console.log();
starSquare();