function simpleCalculator(numOne, numTwo, operator) {
    let operation = getOperation(operator);

    let result = operation (numOne, numTwo);

    function getOperation(operator) {
        switch (operator) {
            case 'multiply':
                return (numOne, numTwo) => numOne * numTwo;
            case 'divide':
                return (numOne, numTwo) => numOne / numTwo;
            case 'add':
                return (numOne, numTwo) => numOne + numTwo;
            case 'subtract':
                return (numOne, numTwo) => numOne - numTwo;
        }
    }

    

    console.log (result);
}

simpleCalculator(5,
    5,
    'multiply'
    );
simpleCalculator (40,
    8,
    'divide'
    );
simpleCalculator (12,
    19,
    'add'
    );
simpleCalculator (50,
    13,
    'subtract'
    );