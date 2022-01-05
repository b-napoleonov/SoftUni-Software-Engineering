//TODO - one wrong test, causes runtime error
function TicTacToe(matrix) {
    let board = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];
    let player1 = 'X';
    let player2 = 'O';
    let ind = 0;
    let isVictory = false;

    for (let move of matrix) {
        move = move.split(' ');
        let row = move[0];
        let col = move[1];
        if(row < 0 && row >= 3 && col < 0 && col >= 3){
            continue;
        }
        if (ind % 2 === 0) {
            debugger;
            if (board[row][col] === false) {
                board[row][col] = player1;
                ind++;
            }
            else {
                console.log('This place is already taken. Please choose another!');
                continue;
            }
        }
        else {
            if (board[row][col] === false) {
                board[row][col] = player2;
                ind++;
            }
            else {
                console.log('This place is already taken. Please choose another!');
                continue;
            }
        }
        for (let i = 0; i < 3; i++) {
            if (checkColumn(i, board) || checkRow(i, board)) {
                isVictory = true;
                break;
            }
        }
        if (isVictory) {
            break;
        }
        if (checkLeftDiagonal(board) || checkRightDiagonal(board)) {
            isVictory = true;
            break;
        }
    }

        if (!isVictory) {
            console.log('The game ended! Nobody wins :(');
        } else {
            let winner = --ind % 2 === 0 ? player1 : player2; 
            console.log(`Player ${winner} wins!`);
        }
        console.log(`${board[0][0]}\t${board[0][1]}\t${board[0][2]}`);
        console.log(`${board[1][0]}\t${board[1][1]}\t${board[1][2]}`);
        console.log(`${board[2][0]}\t${board[2][1]}\t${board[2][2]}`);


    function checkColumn(colIndex, array = []) {
        if (array[0][colIndex] === 'X' && array[1][colIndex] === 'X' && array[2][colIndex] === 'X') {
            return true;
        }
        if (array[0][colIndex] === 'O' && array[1][colIndex] === 'O' && array[2][colIndex] === 'O') {
            return true;
        }
        return false;
    }

    function checkRow(rowIndex, array = []) {
        if (array[rowIndex][0] === 'X' && array[rowIndex][1] === 'X' && array[rowIndex][2] === 'X') {
            return true;
        }
        if (array[rowIndex][0] === 'O' && array[rowIndex][1] === 'O' && array[rowIndex][2] === 'O') {
            return true;
        }
        return false;
    }

    function checkLeftDiagonal(array = []) {
        if (array[0][0] === 'X' && array[1][1] === 'X' && array[2][2] === 'X') {
            return true;
        }
        if (array[0][0] === 'O' && array[1][1] === 'O' && array[2][2] === 'O') {
            return true;
        }
        return false;
    }

    function checkRightDiagonal(array = []) {
        if (array[0][2] === 'X' && array[1][1] === 'X' && array[2][0] === 'X') {
            return true;
        }
        if (array[0][2] === 'O' && array[1][1] === 'O' && array[2][0] === 'O') {
            return true;
        }
        return false;
    }
}

TicTacToe(["0 1","0 0","0 2", "2 0","1 0","1 1","1 2","2 2","2 1","0 0"]);
TicTacToe(["0 0", "0 0", "1 1", "0 1", "1 2", "0 2", "2 2", "1 2", "2 2", "2 1"]);
TicTacToe(["0 1","0 0","0 2","2 0","1 0","1 2","1 1","2 1","2 2","0 0"]);