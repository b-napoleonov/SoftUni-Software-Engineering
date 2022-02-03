function solve(inputArr, criteria){
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }
    
    const tickets = [];

    for (const singleTicket of inputArr) {
        let[destination, price, status] = singleTicket.split('|');
        tickets.push(new Ticket(destination, price, status));
    }

    return criteria === 'price' ? tickets.sort((a, b) => a[criteria] - b[criteria]) : tickets.sort((a, b) => a[criteria].localeCompare(b[criteria]));
}

console.log(solve(['Philadelphia|94.20|available',
 'New York City|95.99|available',
 'New York City|95.99|sold',
 'Boston|126.20|departed'],
'destination'));