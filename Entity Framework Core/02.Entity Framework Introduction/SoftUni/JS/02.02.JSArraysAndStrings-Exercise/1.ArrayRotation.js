function solve(input, numberOfRotation) {
    for (let i = 0; i < numberOfRotation; i++) {
        let elementToMove = input.shift();
        input.push(elementToMove);
    }

    console.log (input.join(' '));
}

solve ([51, 47, 32, 61, 21], 2);
solve ([32, 21, 61, 1], 4);
solve ([2, 4, 15, 31], 5);