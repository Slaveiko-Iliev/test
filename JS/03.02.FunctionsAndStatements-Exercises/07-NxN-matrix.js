function solve(number) {
    let numArray = (number) => new Array (number).fill(number).join(' ');
    
    for (let i = 0; i < number; i++) {
        console.log (numArray(number));
    }
}

solve (3);
solve (7);