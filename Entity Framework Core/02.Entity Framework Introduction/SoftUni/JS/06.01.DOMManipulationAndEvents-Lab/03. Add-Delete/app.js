function addItem() {
    const itemsListElement = document.getElementById('items');
    const newItemTextElement = document.getElementById('newItemText');
    let newLiElement = document.createElement("li");
    let newAElement = document.createElement("a");

    newAElement.addEventListener('click', () => newLiElement.remove());

    newLiElement.textContent = newItemTextElement.value;
    newAElement.textContent = '[Delete]';
    newAElement.href = '#';

    newLiElement.appendChild(newAElement);
    itemsListElement.appendChild(newLiElement);

    newItemTextElement.textContent = '';
}