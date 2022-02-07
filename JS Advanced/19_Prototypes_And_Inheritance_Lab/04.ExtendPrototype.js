function extendProrotype(classToExtend) {
    classToExtend.prototype.species = 'Human';
    classToExtend.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`;
    }
}

class Person {
    constructor(firstName, lastName){
        this.firstName = firstName;
        this.lastName = lastName;
    }

    toString() {
        return `${this.constructor.name} (firstName: ${this.firstName}, lastName: ${this.lastName})`;
    }
}

let person = new Person('Peter', 'Ivanov');
extendProrotype(Person);
console.log(person.toSpeciesString());