function isUpperCase(char) {
    return char === char.toUpperCase();
}

const letter = 'A';
const isUpper = isUpperCase(letter);
console.log(`Буквата "${letter}" е главна: ${isUpper}`);
