function addItem() {
    const inputItemElement = document.getElementById('newItemText');
    const itemsListElement = document.getElementById('items');

    // Create new item element
    const newInputItemElement = document.createElement('li');
    newInputItemElement.textContent = inputItemElement.value;

    // create link element
    const deleteLinkElement = document.createElement('a');
    deleteLinkElement.textContent = '[Delete]';
    deleteLinkElement.href = '#';

    // Add event to link element
    deleteLinkElement.addEventListener('click', () => {
        newInputItemElement.remove();
    });

    // Append link element to newItemElement
    newInputItemElement.appendChild(deleteLinkElement);

    // Append new item element to list
    itemsListElement.appendChild(newInputItemElement);

    // clear input
    inputItemElement.value = '';
}
