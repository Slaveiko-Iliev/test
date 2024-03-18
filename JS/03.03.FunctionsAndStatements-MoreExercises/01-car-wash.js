

function solve(commands) {
    const getOperation = (command, result) => {
        switch (command) {
            case 'soap':
                return result += 10;
            case 'water':
                return result *= 1.2;
            case 'vacuum cleaner':
                return result *= 1.25;
            case 'mud':
                return result *= 0.9;
        }
    }
    let result = 0;

    for (const command of commands) {
        result = getOperation(command,result);
    }

    console.log (`The car is ${result.toFixed(2)}% clean.`);
}

// const getOperation = (command, result) => {
//     switch (command) {
//         case 'soap':
//             return result += 10;
//         case 'water':
//             return result *= 1.2;
//         case 'vacuum cleaner':
//             return result *= 1.25;
//         case 'mud':
//             return result *= 0.9;
//     }
// }

// function solve(commands) {
//     let result = 0;

//     for (const command of commands) {
//         result = getOperation(command,result);
//     }

//     console.log (`The car is ${result.toFixed(2)}% clean.`);
// }

solve(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']);
solve(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]);