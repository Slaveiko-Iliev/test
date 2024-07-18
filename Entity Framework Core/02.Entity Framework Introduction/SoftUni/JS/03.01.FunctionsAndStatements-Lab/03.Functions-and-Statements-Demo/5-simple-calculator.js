function solve(a, b, operator) {
    const operation = getOperation(operator);

    const result = operation(a, b);

    console.log(result);

    function getOperation(operator) {
        switch (operator) {
            case 'multiply':
                return (a, b) => a * b;
            case 'divide':
                return (a, b) => a / b;
            case 'add':
                return (a, b) => a + b;
            case 'subtract':
                return (a, b) => a - b;
        }
    }
}

function fancySolve(a, b, operator) {
    const operations = {
        multiply: (a, b) => a * b,
        divide: (a, b) => a / b,
        add: (a, b) => a + b,
        subtract: (a, b) => a - b,
    }

    console.log(operations[operator](a, b));
}

fancySolve(5,
    5,
    'multiply'
);
