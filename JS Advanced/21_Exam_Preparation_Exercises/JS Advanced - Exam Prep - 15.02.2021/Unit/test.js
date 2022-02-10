const describe = require('mocha').describe;
const assert = require('chai').assert;

let dealership = {
    newCarCost: function (oldCarModel, newCarPrice) {

        let discountForOldCar = {
            'Audi A4 B8': 15000,
            'Audi A6 4K': 20000,
            'Audi A8 D5': 25000,
            'Audi TT 8J': 14000,
        }

        if (discountForOldCar.hasOwnProperty(oldCarModel)) {
            let discount = discountForOldCar[oldCarModel];
            let finalPrice = newCarPrice - discount;
            return finalPrice;
        } else {
            return newCarPrice;
        }
    },

    carEquipment: function (extrasArr, indexArr) {
        let selectedExtras = [];
        indexArr.forEach(i => {
            selectedExtras.push(extrasArr[i])
        });

        return selectedExtras;
    },

    euroCategory: function (category) {
        if (category >= 4) {
            let price = this.newCarCost('Audi A4 B8', 30000);
            let total = price - (price * 0.05)
            return `We have added 5% discount to the final price: ${total}.`;
        } else {
            return 'Your euro category is low, so there is no discount from the final price!';
        }
    }
}

describe('Provided object works fine', () => {
    it('newCarCost() should return the final price of the car', () => {
        assert.equal(dealership.newCarCost('Audi A4 B8', 30000), 15000);
        assert.equal(dealership.newCarCost('Audi A6 4K', 30000), 10000);
        assert.equal(dealership.newCarCost('Audi A8 D5', 30000), 5000);
        assert.equal(dealership.newCarCost('Audi TT 8J', 30000), 16000);
    });

    it('carEquipment() should return the selected extras', () => {
        assert.deepEqual(dealership.carEquipment(['ABS', 'Air Conditioning', 'Alarm', 'Airbag'], [0, 2, 3]), ['ABS', 'Alarm', 'Airbag']);
        assert.deepEqual(dealership.carEquipment(['ABS', 'Air Conditioning', 'Alarm', 'Airbag'], [0, 1, 3]), ['ABS', 'Air Conditioning', 'Airbag']);
        assert.deepEqual(dealership.carEquipment(['ABS', 'Air Conditioning', 'Alarm', 'Airbag'], [0, 1, 2]), ['ABS', 'Air Conditioning', 'Alarm']);
    });

    it('euroCategory() should return the final price of the car', () => {
        assert.equal(dealership.euroCategory(4), 'We have added 5% discount to the final price: 14250.');
        assert.equal(dealership.euroCategory(3), 'Your euro category is low, so there is no discount from the final price!');
        assert.equal(dealership.euroCategory(2), 'Your euro category is low, so there is no discount from the final price!');
    });
})