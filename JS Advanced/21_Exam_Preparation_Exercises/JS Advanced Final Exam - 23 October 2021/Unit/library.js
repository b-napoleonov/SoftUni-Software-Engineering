const describe = require('mocha').describe;
const assert = require('chai').assert;

const library = {
    calcPriceOfBook(nameOfBook, year) {

        let price = 20;
        if (typeof nameOfBook != "string" || !Number.isInteger(year)) {
            throw new Error("Invalid input");
        } else if (year <= 1980) {
            let total = price - (price * 0.5);
            return `Price of ${nameOfBook} is ${total.toFixed(2)}`;
        }
        return `Price of ${nameOfBook} is ${price.toFixed(2)}`;
    },

    findBook: function(booksArr, desiredBook) {
        if (booksArr.length == 0) {
            throw new Error("No books currently available");
        } else if (booksArr.find(e => e == desiredBook)) {
            return "We found the book you want.";
        } else {
            return "The book you are looking for is not here!";
        }

    },
    arrangeTheBooks(countBooks) {
        const countShelves = 5;
        const availableSpace = countShelves * 8;

        if (!Number.isInteger(countBooks) || countBooks < 0) {
            throw new Error("Invalid input");
        } else if (availableSpace >= countBooks) {
            return "Great job, the books are arranged.";
        } else {
            return "Insufficient space, more shelves need to be purchased.";
        }
    }

};

describe('library object works as intended', () =>{
    it('calcPriceOfBook works right', () => {
        assert.throws(() => library.calcPriceOfBook(123, 1999), "Invalid input");
        assert.throws(() => library.calcPriceOfBook("Harry Potter", "1999"), "Invalid input");
        assert.equal(library.calcPriceOfBook("Harry Potter", 1970), "Price of Harry Potter is 10.00");
        assert.equal(library.calcPriceOfBook("Harry Potter", 1980), "Price of Harry Potter is 10.00");
        assert.equal(library.calcPriceOfBook("Harry Potter", 1981), "Price of Harry Potter is 20.00");
    })

    it('findBook works right', () => {
        assert.throws(() => library.findBook([], "Harry Potter"), "No books currently available");
        assert.equal(library.findBook(["Harry Potter", "Troy"], "Harry Potter"), "We found the book you want.");
        assert.equal(library.findBook(["Harry Potter", "Troy"], "Toronto"), "The book you are looking for is not here!");
    })

    it('arrangeBooks works right', () => {
        assert.throws(() => library.arrangeTheBooks(""), "Invalid input");
        assert.throws(() => library.arrangeTheBooks(-2), "Invalid input");
        assert.equal(library.arrangeTheBooks(10), "Great job, the books are arranged.");
        assert.equal(library.arrangeTheBooks(40), "Great job, the books are arranged.");
        assert.equal(library.arrangeTheBooks(41), "Insufficient space, more shelves need to be purchased.");

    })
})