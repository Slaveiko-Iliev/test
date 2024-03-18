let input = `myPass3`;

let arrayOf = input
        .split('');


let checkIfAtLeastTwoDigits = (arrayOf) => arrayOf.filter(char => Number.isFinite(Number(char)));

// console.log([-1, 0, 1, 2, 3, Number(4), Number(0), '', 'test'].filter(Number.isFinite))

console.log (arrayOf);
console.log (checkIfAtLeastTwoDigits(arrayOf));