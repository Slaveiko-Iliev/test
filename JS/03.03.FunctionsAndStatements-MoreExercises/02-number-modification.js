function solve(number) {
    const calculateSum = (number) => number
    .toString()
    .split('')
    .map(element => Number(element))
    .reduce((acc, element) => acc + element,0);
    
    while (calculateSum(number) / number.toString().length <= 5) {
        number = number * 10 + 9;
    }
    return console.log(number);
}

// const calculateSum = (number) => number
//     .toString()
//     .split('')
//     .map(element => Number(element))
//     .reduce((acc, element) => acc + element,0);

// function solve(number) {
//     while (calculateSum(number) / number.toString().length <= 5) {
//         number = number * 10 + 9;
//     }
//     return console.log(number);
// }

solve(101);
solve(5835);