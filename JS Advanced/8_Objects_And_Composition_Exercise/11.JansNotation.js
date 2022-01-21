function solve(inputArr = []) {
  let numbers = [];

  for (const item of inputArr) {
    if (typeof item === "number") {
      numbers.push(parseInt(item));
    } else {
      if (numbers.length < 2) {
        return "Error: not enough operands!";
      }

      let firstNum = numbers.pop();
      let secondNum = numbers.pop();

      switch (item) {
        case "+":
          numbers.push(secondNum + firstNum);
          break;
        case "-":
          numbers.push(secondNum - firstNum);
          break;
        case "*":
          numbers.push(secondNum * firstNum);
          break;
        case "/":
          numbers.push(secondNum / firstNum);
          break;
      }
    }
  }

  return numbers.length > 1 ? "Error: too many operands!" : numbers[0];
}

console.log(solve([3, 4, "+"]));
console.log(solve([5, 3, 4, "*", "-"]));
console.log(solve([7, 33, 8, "-"]));
