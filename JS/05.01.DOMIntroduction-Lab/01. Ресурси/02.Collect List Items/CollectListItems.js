function extractText() {
    const itemListElement = document.getElementById('items');
    const textAreaElement = document.querySelector('#result');

    textAreaElement.value = itemListElement.textContent;
}