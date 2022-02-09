let { Repository } = require("./solution.js");
const assert = require('chai').assert;

//2 tests in judge are failing
describe("Tests class Repository", function () {
    describe("Constructor works right", function () {
        it("nextId returns right id", function () {
            let repo = new Repository();
            assert.equal(repo.nextId(), 0);
            assert.equal(repo.nextId(), 1);
            assert.equal(repo.nextId(), 2);
        });
        it('count getter works right', () => {
            let repo = new Repository();
            assert.equal(repo.count, 0);
            repo.add({});
            assert.equal(repo.count, 1);
            repo.add({});
            assert.equal(repo.count, 2);
        })
    });

    describe("validate works right", function () {
        it('throws error if prop is missing', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);
            assert.throws(() => repo.add({}), Error, 'Property name is missing from the entity!');
        })
        it('throws error if prop is not of correct type', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);
            assert.throws(() => repo.add({ name: 1 , age: 2, birthday: {}}), TypeError, 'Property name is not of correct type!');
        })
    });

    describe("add works right", function () {
        it('adds entity correctly', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);
            repo.add({ name: "Pesho", age: 20, birthday: new Date() });
            assert.equal(repo.count, 1);
        })
        it('returns right id', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);
            assert.equal(repo.add({ name: "Pesho", age: 20, birthday: new Date() }), 0);
            assert.equal(repo.add({ name: "Pesho", age: 20, birthday: new Date() }), 1);
        })
    });

    describe('getId works right', () => {
        it('throws error if entity does not exist', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);
            assert.throws(() => repo.getId(0), Error, 'Entity with id: 0 does not exist!');
        })
        it('returns right entity', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);
            repo.add({ name: "Pesho", age: 20, birthday: new Date() });
            assert.equal(repo.getId(0).name, "Pesho");
        })
    });
    describe('update works fine', () => {
        it('throws error if entity does not exist', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);
            assert.throws(() => repo.update(0, {}), Error, 'Entity with id: 0 does not exist!');
        })
        it('sets entity correctly', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);
            repo.add({ name: "Pesho", age: 20, birthday: new Date() });
            repo.update(0, { name: "Gosho", age: 30, birthday: new Date() });
            assert.equal(repo.getId(0).name, "Gosho");
        })
    });

    describe('del works right', () => {
        it('throws error if entity does not exist', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);
            assert.throws(() => repo.del(0), Error, 'Entity with id: 0 does not exist!');
        })
        it('deletes entity', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);
            repo.add({ name: "Pesho", age: 20, birthday: new Date() });
            repo.del(0);
            assert.equal(repo.count, 0);
        })
    })
});
