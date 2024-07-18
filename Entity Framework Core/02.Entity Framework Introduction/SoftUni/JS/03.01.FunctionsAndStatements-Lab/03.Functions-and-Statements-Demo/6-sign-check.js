function solve(a, b, c) {
    const multipy = (a, b) => a * b;

    if (multipy(multipy(a, b), c) >= 0) {
        console.log('Positive');
    } else {
        console.log('Negative');
    }
}

solve(5,
    12,
    -15
);
