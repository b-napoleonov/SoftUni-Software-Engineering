const describe = require('mocha').describe;
const assert = require('chai').assert;

function sum(arr) {
    let sum = 0;
    for (let num of arr){
        sum += Number(num);
    }
    return sum;
}

describe('Sum numbers', () => {
    it('sums single number', () => {
        assert.equal(sum([1]), 1);
    });
    it('sums multiple numbers', () => {
        assert.equal(sum([1, 2, 3]), 6);
    })
    it('throw NaN if empty array', () => {
        assert.isNaN(sum(['asd']))
    })
});