function factory(face, suit){
    const validFaces = ['A', '2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K'];
    const validSuits = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663'
    }

    if (!validFaces.includes(face) || validSuits[suit] === undefined){
        throw new Error();
    }

    const cardObj = {
        face: face,
        suit: validSuits[suit],
    };

    cardObj.toString = function(){
        return `${this.face}${this.suit}`;
    };

    return cardObj.toString();
}

console.log(factory('A', 'S'));
console.log(factory('10', 'H'));
console.log(factory('1', 'C'));