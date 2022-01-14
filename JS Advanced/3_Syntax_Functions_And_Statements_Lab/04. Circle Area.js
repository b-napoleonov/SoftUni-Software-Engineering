function circleArea(number){
    let inputType = typeof(number);

    if(inputType === 'number'){
    let area = Math.PI * number * number;
    console.log(area.toFixed(2));
    }
    else{
        console.log(`We can not calculate the circle area, because we receive a ${inputType}.`);
    }
}

circleArea(5);
circleArea('name');