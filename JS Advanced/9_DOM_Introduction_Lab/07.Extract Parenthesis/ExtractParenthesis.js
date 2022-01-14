function extract(content) {
    const text = document.getElementById(content).textContent;
    const regex = /\((?<word>[A-Za-z ]+)\)/g;
    const arr = text.match(regex);
    let result = arr.join('; ');
    while (result.includes('(') || result.includes(')')) {
        result = result.replace('(', '');
        result = result.replace(')', '');
    }
    console.log(result);
    return result;
}