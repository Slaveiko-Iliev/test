function solve (input) {
    let oddSum = input
        .filter(element => element % 2 !== 0)
        .reduce((accumulator, currentValue) => accumulator + currentValue, 0);
    let evenSum = input
        .filter(element => element % 2 === 0)
        .reduce((accumulator, currentValue) => accumulator + currentValue, 0);

    console.log (evenSum - oddSum);
}

solve ([1,2,3,4,5,6]);
solve ([3,5,7,9]);
solve ([2,4,6,8,10]);