function addRemoveElements(arr = []) {
    let initialNumber = 1;
    let result = [];
    for (const command of arr) {
        switch (command) {
            case 'add':
                result.push(initialNumber);
                break;
            case 'remove':
                result.pop();
                break;
        }

        initialNumber++;
    }

    if (result.length === 0) {
        console.log('Empty');
        return;
    }
    for (const element of result) {
        console.log(element);
    }
}

addRemoveElements(['add', 'add', 'add', 'add']);
addRemoveElements(['add', 'add', 'remove', 'add', 'add']);
addRemoveElements(['remove', 'remove', 'remove']);