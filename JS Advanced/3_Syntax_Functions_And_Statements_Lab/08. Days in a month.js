function numberOfDays(month, year){
    return new Date(year, month, 0).getDate();
}

console.log(numberOfDays(1, 2012));
console.log(numberOfDays(2, 2021));