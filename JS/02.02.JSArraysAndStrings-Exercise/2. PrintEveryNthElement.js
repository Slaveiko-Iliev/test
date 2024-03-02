function solve(input, N) {
    let output = [];

    for (let i = 0; i < input.length; i+=N) {
        // if (i === 0 || i % N == 0){
        //     output.push(input[i]);
        // }
        output.push(input[i]);
    }

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