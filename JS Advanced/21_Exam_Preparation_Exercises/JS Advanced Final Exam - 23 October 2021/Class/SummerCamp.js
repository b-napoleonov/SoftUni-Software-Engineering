class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = { "child": 150, "student": 300, "collegian": 500 };
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {
        if (!this.priceForTheCamp.hasOwnProperty(condition)) {
            throw new Error('Unsuccessful registration at the camp.');
        }

        if (this.listOfParticipants.find(x => x.name === name)) {
            return `The ${name} is already registered at the camp.`;
        }

        if (money < this.priceForTheCamp[condition]) {
            return `The money is not enough to pay the stay at the camp.`;
        }

        let participant = {
            name,
            condition,
            power: 100,
            wins: 0
        }

        this.listOfParticipants.push(participant);
        return `The ${name} was successfully registered.`;
    }

    unregisterParticipant(name) {
        let participant = this.listOfParticipants.find(p => p.name === name);

        if (!participant) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        this.listOfParticipants = this.listOfParticipants.filter(p => p.name !== name);
        return `The ${name} removed successfully.`;
    }

    timeToPlay(typeOfGame, firstParticipant, secondParticipant) {
        if (secondParticipant) {
            let first = this.listOfParticipants.find(p => p.name === firstParticipant);
            let second = this.listOfParticipants.find(p => p.name === secondParticipant);

            if (!first || !second) {
                throw new Error('Invalid entered name/s.');
            }

            if (first.condition !== second.condition) {
                throw new Error('Choose players with equal condition.');
            }

            if (first.power > second.power) {
                first.wins++;
                return `The ${first.name} is winner in the game ${typeOfGame}.`;
            }
            else if (first.power < second.power) {
                second.wins++;
                return `The ${second.name} is winner in the game ${typeOfGame}.`;
            }
            else {
                return 'There is no winner.';
            }
        }
        else {
            let first = this.listOfParticipants.find(p => p.name === firstParticipant);

            if (!first) {
                throw new Error('Invalid entered name/s.');
            }

            first.power += 20;
            return `The ${first.name} successfully completed the game ${typeOfGame}.`;
        }
    }

    toString() {
        let result = [`${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`];
        this.listOfParticipants.sort((a, b) => b.wins - a.wins);
        result.push(this.listOfParticipants.map(p => `${p.name} - ${p.condition} - ${p.power} - ${p.wins}`).join('\n'));

        return result.join('\n');
    }
}

const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
//console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

console.log(summerCamp.toString());

