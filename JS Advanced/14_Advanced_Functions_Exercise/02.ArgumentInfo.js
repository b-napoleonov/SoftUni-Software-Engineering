function info(...arr){
    const result = {};

    for (const item of arr) {
        let key = typeof item;

        if (!result[key]) {
            result[key] = 1;
        } 
        else {
            result[key]++;
        }

        console.log(`${key}: ${item}`);
    }

    const sorted = Object.entries(result)
    .sort(([,a],[,b]) => b-a)
    .reduce((r, [k, v]) => ({ ...r, [k]: v }), {});

    for (const item in sorted) {
        console.log(`${item} = ${result[item]}`);
    }
}

info('cat', 42, function () { console.log('Hello world!'); });