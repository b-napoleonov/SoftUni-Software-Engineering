function cookingByNumbers(num, op1, op2, op3, op4, op5){
    let number = Number(num);
    let arr = [op1, op2, op3, op4, op5];

    for(let i = 0; i < arr.length; i++){
        let command = arr[i];
        switch(command){
            case 'chop': number /= 2; break;
            case 'dice': number = Math.sqrt(number); break;
            case 'spice': number++; break;
            case 'bake': number *= 3; break;
            case 'fillet': number *= 0.8; break;
        }
        
        console.log(number);
    }
}
cookingByNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cookingByNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet');