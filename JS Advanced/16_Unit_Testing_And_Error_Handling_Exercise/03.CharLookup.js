const describe = require('mocha').describe;
const assert = require('chai').assert;

function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

describe('check lookupChar function', () => {
    it('should return undefined', () => {
        assert.isUndefined(lookupChar(1, 1));
        assert.isUndefined(lookupChar('string', 'string'));
        assert.isUndefined(lookupChar('string',2.2))
    })
    it('returns message if index is outside the bounds of the array', () => {
        assert.equal(lookupChar('string', -1), 'Incorrect index');
        assert.equal(lookupChar('string', 10), 'Incorrect index');
    })
    it('returns correct value when input is correct', () => {
        assert.equal(lookupChar('string', 0), 's');
        assert.equal(lookupChar('string', 1), 't');
        assert.equal(lookupChar('string', 2), 'r');
        assert.equal(lookupChar('string', 3), 'i');
        assert.equal(lookupChar('string', 4), 'n');
        assert.equal(lookupChar('string', 5), 'g');
    })
})