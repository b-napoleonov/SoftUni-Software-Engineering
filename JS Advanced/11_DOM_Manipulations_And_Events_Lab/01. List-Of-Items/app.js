function addItem() {
    let itemToAdd = document.getElementById("newItemText").value;
    const liElement = document.createElement("li");
    liElement.innerHTML = itemToAdd;
    document.getElementById("items").appendChild(liElement);
}