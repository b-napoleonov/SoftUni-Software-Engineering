function solution() {

    class Employee{
        constructor(name, age){
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
            this._index = 0;
        }

        work(){
            if (!Array.isArray(this.tasks[0])) {
                console.log(`${this.name} ${this.tasks[0]}`);
                return;
            }

            if (this._index === this.tasks[0].length) {
                 this._index = 0;
            }

            console.log(`${this.name} ${this.tasks[0][this._index++]}`);
        }

        collectSalary(){
            console.log(`${this.name} received ${this.salary} this month.`);
        }
    }

    class Junior extends Employee{
        constructor(name, age){
            super(name, age);
            this.tasks.push(`is working on a simple task.`);
        }
    }

    class Senior extends Employee{
        constructor(name, age){
            super(name, age);
            this.tasks.push(['is working on a complicated task.', 
            'is taking time off work.',
            'is supervising junior workers.']);
        }
    }

    class Manager extends Employee{
        constructor(name, age){
            super(name, age);
            this.dividend = 0;
            this.tasks.push(['scheduled a meeting.',
            'is preparing a quarterly report.']);
        }

        collectSalary(){
            console.log(`${this.name} received ${this.salary + this.dividend} this month.`);
        }
    }

    return {
        Employee,
        Junior,
        Senior,
        Manager
    }
}

const classes = solution (); 
const junior = new classes.Junior('Ivan',25); 
 
console.log(junior.work());  
console.log(junior.work());  
 
junior.salary = 5811; 
console.log(junior.collectSalary());  
 
const sinior = new classes.Senior('Alex', 31); 
 
console.log(sinior.work());  
console.log(sinior.work());  
console.log(sinior.work());  
console.log(sinior.work());   

sinior.salary = 12050; 
console.log(sinior.collectSalary());  
 
const manager = new classes.Manager('Tom', 55); 
 
manager.salary = 15000; 
console.log(manager.collectSalary());  
manager.dividend = 2500; 
console.log(manager.collectSalary());  