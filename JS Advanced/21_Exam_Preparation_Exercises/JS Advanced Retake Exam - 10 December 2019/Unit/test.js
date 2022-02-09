const ChristmasMovies = require('./ChristmasMovies_Resources');
const assert = require('chai').assert;
//5 tests in judge are failing
describe('ChristmasMovies', () => {
    describe('constructor initialize right props', () => {
        it('should have movieCollection', () => {
            cMovies = new ChristmasMovies;
            cMovies.movieCollection = [];
            assert.isArray(cMovies.movieCollection);
            assert.isEmpty(cMovies.movieCollection);
        });

        it('should have watched', () => {
            cMovies.watched = {};
            assert.isObject(cMovies.watched);
            assert.isEmpty(cMovies.watched);
        });

        it('should have actors', () => {
            cMovies.actors = [];
            assert.isEmpty(cMovies.actors);
            assert.isArray(cMovies.actors);
        });
    })

    describe('buyMovie', () => {
        it('works right with undefined movie', () => {
            cMovies = new ChristmasMovies;
            assert.equal(cMovies.buyMovie('Titanic', ['Jack', 'Rose']), 'You just got Titanic to your collection in which Jack, Rose are taking part!');
        })
        it('throws error if you already own the movie', () => {
            assert.throws(() => cMovies.buyMovie('Titanic', ['Jack', 'Rose']), Error, 'You already own Titanic in your collection!');
        })
    })

    describe('watchMovie', () => {
        it('movie is added to watched collection', () => {
            cMovies = new ChristmasMovies;
            cMovies.buyMovie('Titanic', ['Jack', 'Rose']);
            cMovies.watchMovie('Titanic');
            assert.equal(cMovies.watched['Titanic'], 1);
        })
        it('throws error if movie is not is the collection', () => {
            cMovies = new ChristmasMovies;
            assert.throws(() => cMovies.watchMovie('Titanic'), Error, 'No such movie in your collection!');
        })
    })

    describe('discardMovie', () => {
        it('throws error if movie is not found', () => {
            cMovies = new ChristmasMovies;
            assert.throws(() => cMovies.discardMovie('Inception'), Error, 'Inception is not at your collection!');
        })
        it('movie is removed from watched collection', () => {
            cMovies.buyMovie('Titanic', ['Jack', 'Rose']);
            cMovies.watchMovie('Titanic');
            cMovies.discardMovie('Titanic');
            assert.isUndefined(cMovies.watched['Titanic']);
        })
    })

    describe('favouriteMovie', () => {
        it('throws error when watched list is empty', () => {
            cMovies = new ChristmasMovies;
            assert.throws(() => cMovies.favouriteMovie(), Error, 'You have not watched a movie yet this year!');
        })
        it('proper message is returned', () => {
            cMovies.buyMovie('Titanic', ['Jack', 'Rose']);
            cMovies.watchMovie('Titanic');
            assert.equal(cMovies.favouriteMovie(), 'Your favourite movie is Titanic and you have watched it 1 times!');
        })
    })

    describe('mostStarredActor', () => {
        it('throws error if movie collection is empty', () => {
            cMovies = new ChristmasMovies;
            assert.throws(() => cMovies.mostStarredActor(), Error, 'You have not watched a movie yet this year!');
        })
        it('returns right message', () => {
            cMovies.buyMovie('Titanic', ['Jack', 'Rose']);
            cMovies.buyMovie('Inception', ['Jack', 'Rose']);
            cMovies.watchMovie('Titanic');
            cMovies.watchMovie('Inception');
            assert.equal(cMovies.mostStarredActor(), 'The most starred actor is Jack and starred in 2 movies!');
        })
    })
})