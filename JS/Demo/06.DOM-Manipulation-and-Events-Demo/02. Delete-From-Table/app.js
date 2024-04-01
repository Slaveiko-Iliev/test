function deleteByEmail() {
    const inputEmailElement = document.querySelector('input[name=email]');
    const resultElement = document.getElementById('result');
    const trElements = document.querySelectorAll('table#customers tbody tr')

    // Search for tr element
    const resultTrElement = Array
        .from(trElements)
        .find(trElement => trElement.children[1].textContent.includes(inputEmailElement.value))

    if (resultTrElement) {
        // Delete table row
        resultTrElement.remove();
        
        // Show deleted text
        resultElement.textContent = 'Deleted.';
    } else {
        resultElement.textContent = 'Not found.';
    }

    // Clear input
    inputEmailElement.value = '';
}

