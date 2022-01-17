function filterEmployee(input, criteria){
    let employees = JSON.parse(input);
    const commandArr = criteria.split('-');
    const key = commandArr[0];
    const value = commandArr[1];
    let counter = 0;

    if (key === 'all') {
        console.log(employees.map(e => `${counter++}. ${e.first_name} ${e.last_name} - ${e.email}`).join('\r\n'));
        return;
    }

    employees = employees.filter(e => e[key] === value);
    console.log(employees.map(e => `${counter++}. ${e.first_name} ${e.last_name} - ${e.email}`).join('\r\n'));
}

filterEmployee(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`, 
'gender-Female');
