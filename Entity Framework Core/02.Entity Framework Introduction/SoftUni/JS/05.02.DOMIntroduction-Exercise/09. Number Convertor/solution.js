function solve() {
    document.querySelector('button').addEventListener('click', onClick);

    const selectMenuToElement = document.getElementById('selectMenuTo');
    const binaryOptionElement = selectMenuToElement.querySelector('option');
    binaryOptionElement.value = 'binary';
    binaryOptionElement.textContent = 'Binary';
    const hexadecimlOptionElement = document.createElement('option');
    hexadecimlOptionElement.value = 'hexadecimal';
    hexadecimlOptionElement.textContent = 'Hexadecimal';
    selectMenuToElement.appendChild(hexadecimlOptionElement);

    function reverse(str){
        return str.split("").reverse().join("");
    }

    function convertToBinary(number) {
        let binaryNamber = '';
        while (number !== 0) {
            binaryNamber += number % 2;
            number = Math.floor(number / 2);
        }
        return (reverse(binaryNamber));
    }

    function convertToHexadecimal (number) {
        let hexadecimaNamber = '';
        while (number !== 0) {
            const remainder = number % 16;
            let remainderValue;
            switch (remainder) {
                case 10:
                    value = 'A';
                    break;
                case 11:
                    value = 'B';
                    break;
                case 12:
                    value = 'C';
                    break;
                case 13:
                    value = 'D';
                    break;
                case 14:
                    value = 'E';
                    break;
                case 15:
                    value = 'F';
                    break;
                default:
                    value = remainder;
                    break;
            }
            hexadecimaNamber += value ;
            number = Math.floor(number / 16);
        }
        return (reverse(hexadecimaNamber));
    }

    function onClick(){
        const inputElement = document.getElementById('input');
        const number = Number(inputElement.value);
        const resultElement = document.getElementById('result');

        selectMenuToElement.value === 'binary' ?
            resultElement.value = convertToBinary(number)
            : resultElement.value = convertToHexadecimal(number);
    }
}