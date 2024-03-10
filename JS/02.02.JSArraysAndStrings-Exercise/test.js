// function isUpperCase(char) {
//     return char === char.toUpperCase();
// }

// const letter = 'A';
// const isUpper = isUpperCase(letter);
// console.log(`Буквата "${letter}" е главна: ${isUpper}`);


const strings = ["apple", "banana", "cherry", "date", "fig"];
strings.sort((a, b) => a.length - b.length);
console.log(strings);