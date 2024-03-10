// function solve(input, N) {
//     let output = [];

//     for (let i = 0; i < input.length; i+=N) {
//         output.push(input[i]);
//     }

//     return output;
// }

function solve(input, N) {
    let output = input.filter((element, index) => index % N === 0)

    return output;
}

console.log( solve (['5', 
'20', 
'31', 
'4', 
'20'], 
2
));
console.log( solve (['dsa',
'asd', 
'test', 
'tset'], 
2

));
console.log( solve (['1', 
'2',
'3', 
'4', 
'5'], 
6

));