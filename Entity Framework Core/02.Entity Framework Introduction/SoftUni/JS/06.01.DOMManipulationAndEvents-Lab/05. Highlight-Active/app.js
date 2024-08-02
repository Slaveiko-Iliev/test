function focused() {
    const inputElements = document.querySelectorAll('input');

    for (const inputElement of inputElements) {
        inputElement.addEventListener('focus', () => {
            inputElement.parentElement.className = 'focused'
        });
        inputElement.addEventListener('blur', () => {
            inputElement.parentElement.className = ''
        });

    }
}