const describe = require('mocha').describe;
const assert = require('chai').assert;

const cinema = {
    showMovies: function (movieArr) {

        if (movieArr.length == 0) {
            return 'There are currently no movies to show.';
        } else {
            let result = movieArr.join(', ');
            return result;
        }

    },
    ticketPrice: function (projectionType) {

        const schedule = {
            "Premiere": 12.00,
            "Normal": 7.50,
            "Discount": 5.50
        }
        if (schedule.hasOwnProperty(projectionType)) {
            let price = schedule[projectionType];
            return price;
        } else {
            throw new Error('Invalid projection type.')
        }

    },
    swapSeatsInHall: function (firstPlace, secondPlace) {

        if (!Number.isInteger(firstPlace) || firstPlace <= 0 || firstPlace > 20 ||
            !Number.isInteger(secondPlace) || secondPlace <= 0 || secondPlace > 20 || firstPlace === secondPlace) {
            return "Unsuccessful change of seats in the hall.";
        } else {
            return "Successful change of seats in the hall.";
        }

    }
};

describe('cinema object works as intended', () => {
    it('showMovies works right', () => {
        assert.equal(cinema.showMovies([]), 'There are currently no movies to show.');
        assert.equal(cinema.showMovies(['The Hunger Games: Catching Fire', 'Wreck-It Ralph']), 'The Hunger Games: Catching Fire, Wreck-It Ralph');
    })

    it('ticketPrice works right', () => {
        assert.equal(cinema.ticketPrice('Premiere'), 12);
        assert.equal(cinema.ticketPrice('Normal'), 7.5);
        assert.equal(cinema.ticketPrice('Discount'), 5.5);
        assert.throws(() => cinema.ticketPrice('VIP'), 'Invalid projection type.');
    })

    it('swapSeatsInHall works right', () => {
        assert.equal(cinema.swapSeatsInHall(1, 2), 'Successful change of seats in the hall.');
        assert.equal(cinema.swapSeatsInHall(20, 10), "Successful change of seats in the hall.");
        assert.equal(cinema.swapSeatsInHall(5, 20), "Successful change of seats in the hall.");
        assert.equal(cinema.swapSeatsInHall('1', 2), 'Unsuccessful change of seats in the hall.');
        assert.equal(cinema.swapSeatsInHall(-1, 2), 'Unsuccessful change of seats in the hall.');
        assert.equal(cinema.swapSeatsInHall(0, 2), 'Unsuccessful change of seats in the hall.');
        assert.equal(cinema.swapSeatsInHall(22, 2), 'Unsuccessful change of seats in the hall.');
        assert.equal(cinema.swapSeatsInHall(1.5, 2), 'Unsuccessful change of seats in the hall.');
        assert.equal(cinema.swapSeatsInHall(2), 'Unsuccessful change of seats in the hall.');
        assert.equal(cinema.swapSeatsInHall(1, '2'), 'Unsuccessful change of seats in the hall.');
        assert.equal(cinema.swapSeatsInHall(1, -2), 'Unsuccessful change of seats in the hall.');
        assert.equal(cinema.swapSeatsInHall(1, 0), 'Unsuccessful change of seats in the hall.');
        assert.equal(cinema.swapSeatsInHall(1, 22), 'Unsuccessful change of seats in the hall.');
        assert.equal(cinema.swapSeatsInHall(1, 2.5), 'Unsuccessful change of seats in the hall.');
        assert.equal(cinema.swapSeatsInHall(1, 1), 'Unsuccessful change of seats in the hall.');
        assert.equal(cinema.swapSeatsInHall(1), 'Unsuccessful change of seats in the hall.');

    })
})