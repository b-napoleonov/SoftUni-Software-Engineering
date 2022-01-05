function sortBy2Criteria(arr = []){
    arr.sort((a , b) => a.length - b.length || a.localeCompare(b));
    for (const element of arr) {
        console.log(element);
    }
}

sortBy2Criteria(['alpha', 'beta', 'gamma']);
sortBy2Criteria(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);
sortBy2Criteria(['test', 'Deny', 'omen', 'Default']);