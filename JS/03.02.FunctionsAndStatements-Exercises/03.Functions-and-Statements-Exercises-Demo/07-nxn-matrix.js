const createRow = (num) => new Array(num).fill(num).join(' ');

function solve(number) {
    for (let i = 0; i < number; i++) {
        console.log(createRow(number));
    }
}

solve(7);


function nXNMatrix(num) {
    for (i = 0; i < num; i++) {
        numArray = Array.from({ length: num }, () => num);
        console.log(numArray.join(' '));
    }
}
