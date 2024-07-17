function subtract() {
    const firstNumberElement = document.getElementById('firstNumber');
    const secondNumberElement = document.getElementById('secondNumber');

    const resultElement = document.getElementById('result');
    resultElement.textContent = Number(firstNumberElement.value)  - Number(secondNumberElement.value);
}