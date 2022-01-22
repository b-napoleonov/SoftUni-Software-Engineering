const describe = require('mocha').describe;
const assert = require('chai').assert;

function isSymmetric(arr) {
    if (!Array.isArray(arr)){
        return false; // Non-arrays are non-symmetric
    }
    let reversed = arr.slice(0).reverse(); // Clone and reverse
    let equal = (JSON.stringify(arr) == JSON.stringify(reversed));
    return equal;
}

describe ('Array is symetric', () => {
    it('Input is not Array', () => {
        assert.isNotTrue(isSymmetric({}));
        assert.isNotTrue(isSymmetric('s'));
        assert.isNotTrue(isSymmetric(0));
        assert.isNotTrue(isSymmetric(undefined));
        assert.isNotTrue(isSymmetric(null));
    });
    it('works correctly with numbers', () => {
        assert.equal(isSymmetric([1, 2, 3, 3, 2, 1]), true);
    })
    it('returns false if it is not symetric', () => {
        assert.equal(isSymmetric([1, 2, 3, 4, 5]), false);
    })
    it('should work correctly with strings', () => {
        assert.equal(isSymmetric(['a', 'b', 'c', 'c', 'b', 'a']), true);
    })
    it('should return false if array is from different types', () => {
        assert.equal(isSymmetric([1, 'a', 2, 'b', 3, 'c']), false);
    })
})