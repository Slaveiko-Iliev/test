// Pass function as an argument
function executeOperation(operation, operandA, operandB) {
    const result = operation(operandA, operandB);

    console.log(`The result of this operation is equal to ${result.toFixed(2)}`);
}

function sum(a, b) {
    return a + b;
}

// Pass function by reference
executeOperation(sum, 1, 2);

// Pass function expression body as argument
executeOperation(function(a, b) {
    return a / b
}, 10, 2);

// Pass arrow function body as argument
executeOperation((a, b) => a * b, 2, 5);

