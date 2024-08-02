function solve(numOne, numTwo) {
    let text = ``;
    let result = 0;

    for (let i = numOne; i <= numTwo; i++){
        if (i === numOne) {
            text = `${i}`;
        } else {
            text = `${text} ${i}`;
        }
        result += i;
    }

    console.log (text);
    console.log (`Sum: ${result}`);
}

solve (2, 4);
