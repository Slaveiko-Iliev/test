function addItem() {
    const newItemTextElement = document.getElementById('newItemText');
    const newItemValueElement = document.getElementById('newItemValue');
    const selectElement = document.getElementById('menu');

    const newOption = document.createElement('option');
    newOption.textContent = newItemTextElement.value;
    newOption.value = newItemValueElement.value;
    selectElement.appendChild(newOption);

    newItemTextElement.value = '';
    newItemValueElement.value = '';
}