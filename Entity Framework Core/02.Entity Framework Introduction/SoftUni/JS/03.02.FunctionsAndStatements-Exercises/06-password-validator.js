// let checkLength = (input) => input
//         .length >= 6 && input.length <= 10
//         ? true : console.log(`Password must be between 6 and 10 characters`);

//     let checkOnlyLettersAndDigits = (input) => input
//         .match(/[^a-zA-Z0-9]/g)
//         ? console.log(`Password must consist only of letters and digits`) : true;

//     let checkIfAtLeastTwoDigits = (input) => input
//         .split('')
//         .filter(char => Number.isFinite)
//         .length >= 2
//         ? true : console.log (`Password must have at least 2 digits`);

// function solve(input) {
//     let checkCount = 0;
    
//     if(checkLength(input)){
//         checkCount ++;
//     }
//     if(checkOnlyLettersAndDigits(input)){
//         checkCount ++;
//     }
//     if(checkIfAtLeastTwoDigits(input)){
//         checkCount ++;
//     }

//     if (checkCount === 3){
//         console.log(`Password is valid`);
//     }
// }

function solve(input) {
    let checkCount = 0;

    let checkLength = (input) => input
        .length >= 6 && input.length <= 10
        ? true : console.log(`Password must be between 6 and 10 characters`);

    let checkOnlyLettersAndDigits = (input) => input
        .match(/[^a-zA-Z0-9]/g)
        ? console.log(`Password must consist only of letters and digits`) : true;

    let checkIfAtLeastTwoDigits = (input) => input
        .split('')
        .filter(char => Number.isFinite(Number(char)))
        .length >= 2
        ? true : console.log (`Password must have at least 2 digits`);

    if(checkLength(input)){
        checkCount ++;
    }
    if(checkOnlyLettersAndDigits(input)){
        checkCount ++;
    }
    if(checkIfAtLeastTwoDigits(input)){
        checkCount ++;
    }

    if (checkCount === 3){
        console.log(`Password is valid`);
    }
}

// solve(`logIn`);
solve(`MyPass03`);
// solve('Pa$s$s');