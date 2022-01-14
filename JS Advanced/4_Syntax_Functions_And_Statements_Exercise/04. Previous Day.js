function previousDay(year, month, day) {
    let result = new Date(year, month + 1, day - 1);

    console.log(`${result.getFullYear()}-${result.getMonth() - 1}-${result.getDate()}`);
}

previousDay(2016, 9, 30);
previousDay(2016, 10, 1);