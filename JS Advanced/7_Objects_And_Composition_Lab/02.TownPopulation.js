function townPopulation(arr) {
    const registry = [];
    for (let i = 0; i < arr.length; i++) {
        let town = arr[i].split(' <-> ');
        let name = town[0];
        let population = Number(town[1]);
        if (!registry[name]) {
            registry[name] = 0;
        }
        registry[name] += population;
    }

    for (let town in registry) {
        console.log(`${town} : ${registry[town]}`);
    }
}

townPopulation(['Sofia <-> 1200000', 
'Montana <-> 20000', 
'New York <-> 10000000', 
'Washington <-> 2345000', 
'Las Vegas <-> 1000000']);

townPopulation(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']);