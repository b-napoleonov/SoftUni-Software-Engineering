const describe = require('mocha').describe;
const assert = require('chai').assert;

function createCalculator() {
    let value = 0;
    return {
        add: function(num) { value += Number(num); },
        subtract: function(num) { value -= Number(num); },
        get: function() { return value; }
    }
}

describe ('Calculator works fine', () => {
    it('calculator works right', () => {
        let calc = createCalculator();
        calc.add(2);
        calc.subtract(1);
        assert.equal(calc.get(), 1);
    })
    it('should return object', () => {
        let calc = createCalculator();
        assert.isObject(calc);
    })
    it('should return number', () => {
        let calc = createCalculator();
        calc.add(2);
        calc.subtract(1);
        assert.isNumber(calc.get());
    })
    it('should have add, subtract and get properties', () => {
        let calc = createCalculator();
        assert.isTrue(calc.hasOwnProperty('add'));
        assert.isTrue(calc.hasOwnProperty('subtract'));
        assert.isTrue(calc.hasOwnProperty('get'));
        assert.isFalse(calc.hasOwnProperty('value'));
    })
    it('should work with parsed numbers', () => {
        let calc = createCalculator();
        calc.add('2');
        calc.subtract('1');
        assert.equal(calc.get(), 1);
    })
    it('Should works without adding', () => {
        let calc = createCalculator();
        calc.subtract('1');
        
        assert.equal(calc.get(), -1);
    });
    it('Math operations should not works2', () => {
        let calc = createCalculator();
        calc.add(5);
        calc.value = 6;

        assert.equal(calc.get(), 5);
    });
})