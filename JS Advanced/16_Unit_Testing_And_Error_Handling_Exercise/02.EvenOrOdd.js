const describe = require('mocha').describe;
const assert = require('chai').assert;

function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

describe('Checking isAddOrEven function', () => {
    it('returns undefined when input is not string', () => {
        assert.isUndefined(isOddOrEven([1, 2, 3]));
    })
    it('works right for string with even lngth', () => {
        assert.equal(isOddOrEven('even'), 'even');
    })
    it('works right for string with odd lngth', () => {
        assert.equal(isOddOrEven('pesho'), 'odd');
    })
    it('works correctly overall', () => {
        assert.equal(isOddOrEven('tree'), 'even');
        assert.equal(isOddOrEven('tea'), 'odd');
        assert.equal(isOddOrEven('gosho'), 'odd');
        assert.equal(isOddOrEven('england'), 'odd');
        assert.equal(isOddOrEven('usa'), 'odd');
    })
})