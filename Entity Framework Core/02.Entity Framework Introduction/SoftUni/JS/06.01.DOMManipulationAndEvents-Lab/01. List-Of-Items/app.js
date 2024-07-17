function addItem() {
    const itemsElement = document.getElementById('items');
    const newItemTextElement = document.getElementById('newItemText');
    const newLiElement = document.createElement('li');
    newLiElement.textContent = newItemTextElement.value;
    itemsElement.appendChild(newLiElement);
}