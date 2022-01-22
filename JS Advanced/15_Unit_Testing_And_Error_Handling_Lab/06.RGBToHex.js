const describe = require('mocha').describe;
const assert = require('chai').assert;

function rgbToHexColor(red, green, blue) {
    if (!Number.isInteger(red) || (red < 0) || (red > 255)){
        return undefined; // Red value is invalid
    }
    if (!Number.isInteger(green) || (green < 0) || (green > 255)){
        return undefined; // Green value is invalid
    }
    if (!Number.isInteger(blue) || (blue < 0) || (blue > 255)){
        return undefined; // Blue value is invalid
    }
    return "#" +
        ("0" + red.toString(16).toUpperCase()).slice(-2) +
        ("0" + green.toString(16).toUpperCase()).slice(-2) +
        ("0" + blue.toString(16).toUpperCase()).slice(-2);
}

describe('RGB to Hex converter', () => {
    it('returns undefined if red is not a number', () => {
        assert.equal(rgbToHexColor('red', 0, 0), undefined);
    })
    it('returns undefined if red is less than 0', () => {
        assert.equal(rgbToHexColor(-1, 0, 0), undefined);
    })
    it('returns undefined if red is more than 255', () => {
        assert.equal(rgbToHexColor(256, 0, 0), undefined);
    })
    it('returns undefined if green is not a number', () => {
        assert.equal(rgbToHexColor(0, 'green', 0), undefined);
    })
    it('returns undefined if green is less than 0', () => {
        assert.equal(rgbToHexColor(0, -1, 0), undefined);
    })
    it('returns undefined if green is more than 255', () => {
        assert.equal(rgbToHexColor(0, 256, 0), undefined);
    })
    it('returns undefined if blue is not a number', () => {
        assert.equal(rgbToHexColor(0, 0, 'blue'), undefined);
    })
    it('returns indefined if blue is less than 0', () => {
        assert.equal(rgbToHexColor(0, 0, -1), undefined);
    })
    it('returns undefined if blue is more than 255', () => {
        assert.equal(rgbToHexColor(0, 0, 256), undefined);
    })
    it('Should work with:', () => {
        assert.equal(rgbToHexColor(0,0,0), '#000000');
        assert.equal(rgbToHexColor(255,50,154), '#FF329A');
        assert.equal(rgbToHexColor(255,255,255), '#FFFFFF');
    })
    it('Should not works any other types', () => {
        assert.isUndefined(rgbToHexColor([], [], []));
        assert.isUndefined(rgbToHexColor({}, {}, {}));
        assert.isUndefined(rgbToHexColor('a', 'b', 'c'));
        assert.isUndefined(rgbToHexColor('1', '2', '3'));
        assert.isUndefined(rgbToHexColor(undefined, undefined, undefined));
        assert.isUndefined(rgbToHexColor(null, null, null));
        assert.isUndefined(rgbToHexColor([], {}, 'a'));
        assert.isUndefined(rgbToHexColor(undefined, null, '1'));
    });
    it('Should return string', () => {
        assert.equal(typeof(rgbToHexColor(1,1,1)), 'string');
    })
})