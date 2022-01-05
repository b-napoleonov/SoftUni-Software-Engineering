function Pie(arr, firstTargetFlavor, secondTargetFlavor) {
    return arr.slice(arr.indexOf(firstTargetFlavor), arr.indexOf(secondTargetFlavor) + 1);
}

console.log(Pie(['Pumpkin Pie',
    'Key Lime Pie',
    'Cherry Pie',
    'Lemon Meringue Pie',
    'Sugar Cream Pie'],
    'Key Lime Pie',
    'Lemon Meringue Pie'
));

console.log(Pie(['Apple Crisp',
    'Mississippi Mud Pie',
    'Pot Pie',
    'Steak and Cheese Pie',
    'Butter Chicken Pie',
    'Smoked Fish Pie'],
    'Pot Pie',
    'Smoked Fish Pie'
));