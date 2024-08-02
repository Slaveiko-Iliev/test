const findCorrectDivisor = (number, divisor) => number % divisor === 0;

let calculateSum = numArray => numArray.reduce((acc, num) => acc + num,0);

const isPerfect = (number, sum) => number === sum ? console.log (`We have a perfect number!`) : console.log(`It's not so perfect.`);

function solve(number) {
    
let numArray = [];

for (let divisor = 1; divisor < number; divisor++) {
    if (findCorrectDivisor (number, divisor)) {
        numArray.push(divisor);
    } 
}

let sum = calculateSum (numArray);

isPerfect(number, sum);

}

solve(6);
solve(28);
solve(1236498);