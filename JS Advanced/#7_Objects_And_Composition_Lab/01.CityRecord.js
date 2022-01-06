function createObject(name, population, treasury){
    var city = {};
    city.name = name;
    city.population = population;
    city.treasury = treasury;
    return city;
}

console.log(createObject('Tortuga', 7000, 15000));
console.log(createObject('Santo Domingo', 12000, 23500));