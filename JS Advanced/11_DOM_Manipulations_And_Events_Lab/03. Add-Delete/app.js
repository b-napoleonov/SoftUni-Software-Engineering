function addItem() {
    let itemToAdd = document.getElementById("newItemText").value;
    const liElement = document.createElement("li");
    liElement.innerHTML = itemToAdd;

    const btnElement = document.createElement("a");
    btnElement.href = '#';
    btnElement.innerHTML = '[Delete]';
    btnElement.addEventListener('click', eventHandler);

    liElement.appendChild(btnElement);
    document.getElementById("items").appendChild(liElement);

    function eventHandler(e){
        let parent = btnElement.parentNode;
        document.getElementById("items").removeChild(parent);
    }
}