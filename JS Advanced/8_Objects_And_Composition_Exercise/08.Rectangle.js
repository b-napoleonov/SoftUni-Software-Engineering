function rectangle(width, height, color) {
    return obj = {
        width,
        height,
        color : color[0].toUpperCase() + color.substring(1),
        calcArea : () => obj.width * obj.height
    };
}

let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());
