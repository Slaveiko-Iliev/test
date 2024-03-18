function solve([x1, y1, x2, y2]) {
    function findDistanceBetweenPoints  ([x1, y1, x2, y2]){
        return Math.sqrt((x2-x1)**2 + (y2-y1)**2);
    } 
    
    const isValidDistance = ([x1, y1, x2, y2]) => Number.isInteger(findDistanceBetweenPoints([x1, y1, x2, y2]));

    const isValidBetweenPointOneAndStart = isValidDistance ([x1, y1, 0, 0]);
    const isValidBetweenPointTwoAndStart = isValidDistance ([x2, y2, 0, 0]);
    const isValidBetweenPoints = isValidDistance ([x1, y1, x2, y2]);

    let distanceStatus = isValidBetweenPointOneAndStart ? 'valid' : 'invalid';
    console.log(`{${x1}, ${y1}} to {0, 0} is ${distanceStatus}`);

    distanceStatus = isValidBetweenPointTwoAndStart ? 'valid' : 'invalid';
    console.log(`{${x2}, ${y2}} to {0, 0} is ${distanceStatus}`);

    distanceStatus = isValidBetweenPoints ? 'valid' : 'invalid';
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${distanceStatus}`);
}


// function findDistanceBetweenPoints  ([x1, y1, x2, y2]){
//     return Math.sqrt((x2-x1)**2 + (y2-y1)**2);
// } 

// const isValidDistance = ([x1, y1, x2, y2]) => Number.isInteger(findDistanceBetweenPoints([x1, y1, x2, y2]));

// function solve([x1, y1, x2, y2]) {
//     const isValidBetweenPointOneAndStart = isValidDistance ([x1, y1, 0, 0]);
//     const isValidBetweenPointTwoAndStart = isValidDistance ([x2, y2, 0, 0]);
//     const isValidBetweenPoints = isValidDistance ([x1, y1, x2, y2]);

//     let distanceStatus = isValidBetweenPointOneAndStart ? 'valid' : 'invalid';
//     console.log(`{${x1}, ${y1}} to {0, 0} is ${distanceStatus}`);

//     distanceStatus = isValidBetweenPointTwoAndStart ? 'valid' : 'invalid';
//     console.log(`{${x2}, ${y2}} to {0, 0} is ${distanceStatus}`);

//     distanceStatus = isValidBetweenPoints ? 'valid' : 'invalid';
//     console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${distanceStatus}`);
// }

solve([3, 0, 0, 4]);
solve([2, 1, 1, 1]);