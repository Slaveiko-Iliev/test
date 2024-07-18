function solve(numOne, sign, numTwo) {
    let result = 0;    
    
    switch (sign) {
            case `+`:
                result = numOne + numTwo;
                break;
            case `-`:
                result = numOne - numTwo;
                break;
            case `/`:
                result = numOne / numTwo;
                break;
            case `*`:
                result = numOne * numTwo;
                break;
        
        }

        console.log (result.toFixed(2));
}

solve(5,
    '+',
    10);
solve(25.5,
    '-',
    3);