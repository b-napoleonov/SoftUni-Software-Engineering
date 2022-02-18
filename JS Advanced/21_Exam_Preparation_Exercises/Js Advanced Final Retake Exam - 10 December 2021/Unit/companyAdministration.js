const describe = require('mocha').describe;
const assert = require('chai').assert;

const companyAdministration = {

    hiringEmployee(name, position, yearsExperience) {
        if (position == "Programmer") {
            if (yearsExperience >= 3) {
                return `${name} was successfully hired for the position ${position}.`;
            } else {
                return `${name} is not approved for this position.`;
            }
        }
        throw new Error(`We are not looking for workers for this position.`);
    },
    calculateSalary(hours) {

        let payPerHour = 15;
        let totalAmount = payPerHour * hours;

        if (typeof hours !== "number" || hours < 0) {
            throw new Error("Invalid hours");
        } else if (hours > 160) {
            totalAmount += 1000;
        }
        return totalAmount;
    },
    firedEmployee(employees, index) {

        let result = [];

        if (!Array.isArray(employees) || !Number.isInteger(index) || index < 0 || index >= employees.length) {
            throw new Error("Invalid input");
        }
        for (let i = 0; i < employees.length; i++) {
            if (i !== index) {
                result.push(employees[i]);
            }
        }
        return result.join(", ");
    }

}

describe('companyAdministration Object works as intended', () => {
    it('hiringEmployee works right', () => {
        assert.throws(() => companyAdministration.hiringEmployee("John", "Plumber", 2), Error, "We are not looking for workers for this position.");
        assert.equal(companyAdministration.hiringEmployee("John", "Programmer", 3), "John was successfully hired for the position Programmer.");
        assert.equal(companyAdministration.hiringEmployee("John", "Programmer", 4), "John was successfully hired for the position Programmer.");
        assert.equal(companyAdministration.hiringEmployee("John", "Programmer", 2), "John is not approved for this position.");
    })

    it('calculateSalary works right', () => {
        assert.throws(() => companyAdministration.calculateSalary(-1), Error, "Invalid hours");
        assert.throws(() => companyAdministration.calculateSalary('1'), Error, "Invalid hours");
        assert.equal(companyAdministration.calculateSalary(0), 0);
        assert.equal(companyAdministration.calculateSalary(160), 15 * 160);
        assert.equal(companyAdministration.calculateSalary(161), 15 * 161 + 1000);
    })

    it('fireEmployee works right', () => {
        assert.throws(() => companyAdministration.firedEmployee(undefined, 0), Error, "Invalid input");
        assert.throws(() => companyAdministration.firedEmployee(['Pesho', 'Gosho'], '1'), Error, "Invalid input");
        assert.throws(() => companyAdministration.firedEmployee(['Pesho', 'Gosho'], -1), Error, "Invalid input");
        assert.throws(() => companyAdministration.firedEmployee(['Pesho', 'Gosho'], 2), Error, "Invalid input");
        assert.throws(() => companyAdministration.firedEmployee(['Pesho', 'Gosho'], 3), Error, "Invalid input");
        assert.equal(companyAdministration.firedEmployee(['Pesho', 'Gosho'], 0), "Gosho");
        assert.equal(companyAdministration.firedEmployee(['Pesho'], 0), "");
    })
})