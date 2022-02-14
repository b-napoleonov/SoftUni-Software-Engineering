const describe = require('mocha').describe;
const assert = require('chai').assert;

const numberOperations = {
    powNumber: function (num) {
        return num * num;
    },
    numberChecker: function (input) {
        input = Number(input);

        if (isNaN(input)) {
            throw new Error('The input is not a number!');
        }

        if (input < 100) {
            return 'The number is lower than 100!';
        } else {
            return 'The number is greater or equal to 100!';
        }
    },
    sumArrays: function (array1, array2) {

        const longerArr = array1.length > array2.length ? array1 : array2;
        const rounds = array1.length < array2.length ? array1.length : array2.length;

        const resultArr = [];

        for (let i = 0; i < rounds; i++) {
            resultArr.push(array1[i] + array2[i]);
        }

        resultArr.push(...longerArr.slice(rounds));

        return resultArr
    }
};

describe('numberOperations object works right', () => {
    it('function powNumber works right', () => {
        assert.equal(numberOperations.powNumber(2), 4);
        assert.equal(numberOperations.powNumber(3), 9);
        assert.equal(numberOperations.powNumber(-2), 4);
        assert.equal(numberOperations.powNumber(0), 0);
    })

    it('function numberChecker works right', () => {
        assert.equal(numberOperations.numberChecker(2), 'The number is lower than 100!');
        assert.equal(numberOperations.numberChecker(100), 'The number is greater or equal to 100!');
        assert.equal(numberOperations.numberChecker('2'), 'The number is lower than 100!');
        assert.throws(() => numberOperations.numberChecker('a'), Error, 'The input is not a number!');
    })

    it('sumArrays works right', () => {
        assert.deepEqual(numberOperations.sumArrays([1, 2, 3], [4, 5, 6]), [5, 7, 9]);
        assert.deepEqual(numberOperations.sumArrays([1, 2, 3], [4, 5, 6, 7]), [5, 7, 9, 7]);
        assert.deepEqual(numberOperations.sumArrays([1, 2, 3, 4], [4, 5, 6, 7]), [5, 7, 9, 11]);
    })
})