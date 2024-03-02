function solve(input) {
    let emptyArray = [];
    input.sort(function(a, b){return a-b});
    while (input.length > 0) {
        emptyArray.push(input.shift());
        emptyArray.push(input.pop());
    }
    return emptyArray;
}

console.log (solve ([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));