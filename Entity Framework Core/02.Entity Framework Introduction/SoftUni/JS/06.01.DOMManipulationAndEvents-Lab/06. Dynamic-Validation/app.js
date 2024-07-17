function validate() {
    const inputEmailElement = document.getElementById('email');
    const pattern = /[a-z]+@[a-z]+\.[a-z]+/;

    inputEmailElement.addEventListener('change', (event) => {
        if (!pattern.test(event.target.value)){
            inputEmailElement.classList.add('error');
        } else {
            inputEmailElement.classList.remove('error');
        }
    });

    inputEmailElement.value = '';
}