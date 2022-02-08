(function solve(){

    Array.prototype.last = function(){
        return this[this.length - 1];
    };

    Array.prototype.skip = function(n){
        let result = this.slice(n);
        return result;
    };

    Array.prototype.take = function(n){
        let result = this.slice(0, n + 1);
        return result;
    }

    Array.prototype.sum = function(){
        return this.reduce((a, b) => a + b);
    }

    Array.prototype.average = function(){
        return this.reduce((a, b) => a + b) / this.length;
    }
})();