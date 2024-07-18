function solve(input) {
    let commandInfo = input.split(`, `);
    
    let result = Number(commandInfo[0]);

    for (let i = 1; i <= 5; i++) {
        switch (commandInfo[i]) {
            case `chop`:
                result /= 2;
                break;
            case `dice`:
                result = Math.sqrt(result);
                break;
            case `spice`:
                result += 1;
                break;
            case `bake`:
                result *= 3;
                break;
            case `fillet`:
                result *= 0.8;
                break;
        }

        console.log (result);
    }
}

solve ('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve ('9', 'dice', 'spice', 'chop', 'bake', 'fillet');