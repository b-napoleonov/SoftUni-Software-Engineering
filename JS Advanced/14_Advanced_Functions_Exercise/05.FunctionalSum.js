function add(number){
    let sum = 0;
    sum += number;

    function calc(num){
        sum += num;
        return calc;
    }
    
    calc.toString = () => sum;

    return calc;
}

console.log(Number(add(1)));
console.log(Number(add(1)(6)(-3)));