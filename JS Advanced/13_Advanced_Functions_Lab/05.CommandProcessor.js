function solution(){
    let result = "";

    function append(text){
        return result += text;
    }

    function removeStart(n){
        return result = result.substring(n);
    }

    function removeEnd(n){
        return result = result.substring(0, result.length - n);
    }

    function print(){
        console.log(result);
    }

    return {
        append,
        removeStart,
        removeEnd,
        print
    }
}

let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();
