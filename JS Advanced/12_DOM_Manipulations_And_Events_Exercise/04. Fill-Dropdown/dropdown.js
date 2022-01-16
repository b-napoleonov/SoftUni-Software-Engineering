function addItem() {
    const textItem = document.getElementById('newItemText');
    const valueItem = document.getElementById('newItemValue');
    const text = textItem.value;
    const value = valueItem.value;

    const option = document.createElement('option');
    option.text = text;
    option.value = value;

    document.getElementById('menu').appendChild(option);

    textItem.value = '';
    valueItem.value = '';
}