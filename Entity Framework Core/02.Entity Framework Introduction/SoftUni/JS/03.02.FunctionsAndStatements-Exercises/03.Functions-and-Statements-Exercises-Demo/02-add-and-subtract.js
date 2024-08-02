function solve(first, second, third) {
    const sum = (a, b) => a + b;
    const subtract = (a, b) => a - b;

    const result = subtract(sum(first, second), third);
    
    console.log(result);
}

solve(23,
    6,
    10
)
