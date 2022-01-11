function colorize() {
    const arr = Array.from(document.getElementsByTagName('table')[0].querySelectorAll('tr:nth-child(even)'));
    for (const row of arr) {
        row.style.backgroundColor = 'teal';
    }
}