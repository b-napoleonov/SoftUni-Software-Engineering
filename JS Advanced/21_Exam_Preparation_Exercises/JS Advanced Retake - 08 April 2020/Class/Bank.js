//2 tests in judge are failing
class Bank{
    constructor(bankName){
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer){
        if (this.allCustomers.find(c => c.personalId === customer.personalId)){
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        }

        let {firstName, lastName, personalId} = customer;
        const resultCustomer = {
            firstName,
            lastName,
            personalId,
        }
        customer.totalMoney = 0;
        customer.transactions = [];
        this.allCustomers.push(customer);
        return resultCustomer;
    }

    depositMoney(personalId, amount){
        const customer = this.allCustomers.find(c => c.personalId === personalId)

        if (customer == undefined) {
            throw new Error('We have no customer with this ID!');
        }

        customer.totalMoney += Number(amount);
        customer.transactions.unshift(`${customer.firstName} ${customer.lastName} made depostit of ${amount}$!`);
        return `${customer.totalMoney}$`;
    }

    withdrawMoney (personalId, amount){
        const customer = this.allCustomers.find(c => c.personalId === personalId)

        if (customer == undefined) {
            throw new Error('We have no customer with this ID!');
        }

        if (customer.totalMoney < amount) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
        }

        customer.totalMoney -= amount;
        customer.transactions.unshift(`${customer.firstName} ${customer.lastName} withdrew ${amount}$!`);
        return `${customer.totalMoney}$`;
    }

    customerInfo (personalId){
        const customer = this.allCustomers.find(c => c.personalId === personalId)
        let counter = customer.transactions.length;

        if (customer == undefined) {
            throw new Error('We have no customer with this ID!');
        }

        const result = [
            `Bank name: ${this._bankName}`,
            `Customer name: ${customer.firstName} ${customer.lastName}`,
            `Customer ID: ${customer.personalId}`,
            `Total Money: ${customer.totalMoney}$`,
            'Transactions:',
            customer.transactions.map(t => `${counter-- + '.' + ' ' + t}`).join('\n')
        ];

        return result.join('\n').trim();
    }
}

let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267}));
console.log(bank.newCustomer({firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596}));
bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596,555);
console.log(bank.withdrawMoney(6233267, 125));
console.log(bank.customerInfo(6233267));