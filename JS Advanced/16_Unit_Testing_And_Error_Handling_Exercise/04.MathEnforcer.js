const describe = require('mocha').describe;
const assert = require('chai').assert;

let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

describe('check mathEnforcer function', () => {
    it('should work right', () => {
        assert.equal(mathEnforcer.addFive(5), 10);
        assert.equal(mathEnforcer.addFive(5.5), 10.5);
        assert.equal(mathEnforcer.addFive(0), 5);
        assert.equal(mathEnforcer.addFive(-1), 4);
        assert.equal(mathEnforcer.subtractTen(-1), -11);
        assert.equal(mathEnforcer.subtractTen(-1.1), -11.1);
        assert.equal(mathEnforcer.subtractTen(10), 0);
        assert.equal(mathEnforcer.subtractTen(20), 10);
        assert.equal(mathEnforcer.sum(20,20), 40);
        assert.equal(mathEnforcer.sum(0,0), 0);
        assert.equal(mathEnforcer.sum(0.5,0.5), 1);
        assert.equal(mathEnforcer.sum(-20,20), 0);
        assert.equal(mathEnforcer.sum(-20,30), 10);
        assert.equal(mathEnforcer.sum(-30,20), -10);
    })
    it('should return undefined', () => {
        assert.isUndefined(mathEnforcer.addFive({}));
        assert.isUndefined(mathEnforcer.addFive([]));
        assert.isUndefined(mathEnforcer.addFive(null));
        assert.isUndefined(mathEnforcer.addFive(undefined));
        assert.isUndefined(mathEnforcer.addFive(''));
        assert.isUndefined(mathEnforcer.subtractTen([]));
        assert.isUndefined(mathEnforcer.subtractTen(null));
        assert.isUndefined(mathEnforcer.subtractTen(undefined));
        assert.isUndefined(mathEnforcer.subtractTen(''));
        assert.isUndefined(mathEnforcer.subtractTen({}));
        assert.isUndefined(mathEnforcer.sum({},1));
        assert.isUndefined(mathEnforcer.sum([],1));
        assert.isUndefined(mathEnforcer.sum('',1));
        assert.isUndefined(mathEnforcer.sum(null,1));
        assert.isUndefined(mathEnforcer.sum(undefined,1));
        assert.isUndefined(mathEnforcer.sum(1,{}));
        assert.isUndefined(mathEnforcer.sum(1,[]));
        assert.isUndefined(mathEnforcer.sum(1,''));
        assert.isUndefined(mathEnforcer.sum(1,null));
        assert.isUndefined(mathEnforcer.sum(1,undefined));
    })
})