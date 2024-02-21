function solve (numOne, numTwo, sign) {

    let result;

    switch (sign) {
        case `+`:
            result = numOne + numTwo;
            break;
        case `-`:
            result = numOne - numTwo;
            break;
        case `*`:
            result = numOne * numTwo;
            break;
        case `/`:
            result = numOne / numTwo;
            break;
        case `%`:
            result = numOne % numTwo;
            break;
        case `**`:
            result = numOne ** numTwo;
            break;

            
    }

    console.log (result);
}

solve (2,3, `+`);
solve (2,3, `*`);
solve (2,3, `/`);
solve (2,3, `**`);