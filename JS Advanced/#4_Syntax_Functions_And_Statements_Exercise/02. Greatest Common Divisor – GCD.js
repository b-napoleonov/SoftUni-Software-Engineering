function GCD(a, b) {
    if (b == 0) {
        return a;
    }
    return GCD(b, a % b);
}

console.log(GCD(15, 5));
console.log(GCD(2154, 458));