const describe = require('mocha').describe;
const assert = require('chai').assert;

const testNumbers = {
    sumNumbers: function (num1, num2) {
        let sum = 0;

        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        } else {
            sum = (num1 + num2).toFixed(2);
            return sum
        }
    },
    numberChecker: function (input) {
        input = Number(input);

        if (isNaN(input)) {
            throw new Error('The input is not a number!');
        }

        if (input % 2 === 0) {
            return 'The number is even!';
        } else {
            return 'The number is odd!';
        }

    },
    averageSumArray: function (arr) {

        let arraySum = 0;

        for (let i = 0; i < arr.length; i++) {
            arraySum += arr[i]
        }

        return arraySum / arr.length
    }
};

describe('object testNumbers works right', () => {
    it('sumNumbers works right', () => {
        assert.equal(testNumbers.sumNumbers(1, 2), 3);
        assert.equal(testNumbers.sumNumbers(-1, -2.5), -3.5);
        assert.equal(testNumbers.sumNumbers(1, 2.5), 3.5);
        assert.equal(testNumbers.sumNumbers(1, '2'), undefined);
    })

    it('numberChecker works right', () => {
        assert.equal(testNumbers.numberChecker(1), 'The number is odd!');
        assert.equal(testNumbers.numberChecker(2), 'The number is even!');
        assert.throws(() => testNumbers.numberChecker('Pesho'), 'The input is not a number!');
    })

    it('averageSumArray works right', () => {
        assert.equal(testNumbers.averageSumArray([1, 2, 3, 4, 5]), 3);
        assert.equal(testNumbers.averageSumArray([1, 2, 3, 4, 5, 6]), 3.5);
        assert.equal(testNumbers.averageSumArray([1]), 1);
        assert.deepEqual(testNumbers.averageSumArray([]), NaN);
    })
});