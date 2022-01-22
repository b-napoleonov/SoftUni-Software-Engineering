function printDeckOfCards(cardsArr){
    const validFaces = ['A', '2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K'];
    const validSuits = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663'
    }

    let result = '';
    for (const card of cardsArr) {
        let face = '';
        let suit = '';
        if (card.length !== 2) {
            face = card.slice(0, card.length - 1);
            suit = card[2];
        }
        else{
            face = card[0];
            suit = card[1];
        }

        if (!validFaces.includes(face) || validSuits[suit] === undefined){
            console.log('Invalid card:' + " " + face + suit);
            return;
        }

        result += `${face}${validSuits[suit]} `;
    }

    console.log(result);
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);