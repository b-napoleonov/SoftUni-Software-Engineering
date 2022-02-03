function juiceFactory(inputArr) {
  let juices = {};
  let result = {};

  for (const input of inputArr) {
    let [juiceName, quantity] = input.split(" => ");

    if (!juices.hasOwnProperty(juiceName)) {
      juices[juiceName] = 0;
    }

    juices[juiceName] += Number(quantity);

    if (juices[juiceName] >= 1000) {
      result[juiceName] = Math.floor(juices[juiceName] / 1000);
    }
  }

  for (const juice in result) {
    console.log(`${juice} => ${result[juice]}`);
  }
}

juiceFactory([
  "Orange => 2000",
  "Peach => 1432",
  "Banana => 450",
  "Peach => 600",
  "Strawberry => 549",
]);

console.log("*".repeat(30));

juiceFactory([
  "Kiwi => 234",
  "Pear => 2345",
  "Watermelon => 3456",
  "Kiwi => 4567",
  "Pear => 5678",
  "Watermelon => 6789",
]);
