function deleteByEmail() {
    let email = document.getElementsByTagName('input')[0].value;
    let tableRows = document.getElementsByTagName('tr')[0];
    const result = document.getElementById('result');

    for (let i = 1; i < tableRows.length; i++) {
        if (tableRows[i].children[1].textContent.includes(email)) {
            result.innerHTML = 'Deleted.';
            tableRows[i].remove();
        }
            
        result.innerHTML = 'Not found.';
    }
}