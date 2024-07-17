function solve(a, b, c) {
    const sum = () => a + b;
    const subtract = () => sum() - c;


    console.log (subtract());
}

solve(23,
    6,
    10);
solve(1,
    17,
    30);
solve(42,
    58,
    100);