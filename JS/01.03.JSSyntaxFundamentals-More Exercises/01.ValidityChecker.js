//  function solve(x1, y1, x2, y2) {
//     let beginningPoint = 0;
//     let distanceFirstPointAndBeginningPoint = Math.sqrt((x2-x1)**2 + (beginningPoint-beginningPoint)**2);
    
//     if (Math.abs(distanceFirstPointAndBeginningPoint) - Math.floor(distanceFirstPointAndBeginningPoint) === 0) {
//         console.log (`{${x1}, ${y1}} to {${beginningPoint}, ${beginningPoint}} is valid`);
//     } else {
//         console.log(`{${x1}, ${y1}} to {${beginningPoint}, ${beginningPoint}} is invalid`);
//     }

//     let distanceSecondPointAndBeginningPoint = Math.sqrt((x2-x1)**2 + (beginningPoint-beginningPoint)**2);

//     if (Math.abs(distanceSecondPointAndBeginningPoint) - Math.floor(distanceSecondPointAndBeginningPoint) === 0) {
//         console.log (`{${x2}, ${y2}} to {${beginningPoint}, ${beginningPoint}} is valid`);
//     } else {
//         console.log(`{${x2}, ${y2}} to {${beginningPoint}, ${beginningPoint}} is invalid`);
//     }

//     let distanceBetweenPoints = Math.sqrt((x2-x1)**2 + (y2-y1)**2);
    
//     if (Math.abs(distanceBetweenPoints) - Math.floor(distanceBetweenPoints) === 0) {
//         console.log (`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
//     } else {
//         console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
//     }
//  }

// //  solve(3, 0, 0, 4);
//  solve(2, 1, 1, 1);


function solve(...input) {
    let x1 = Number(input[0]);
    let y1 = Number(input[1]);
 
    let x2 = Number(input[2]);
    let y2 = Number(input[3]);
 
    console.log(Number.isInteger(result(x1, y1))
        ? `{${x1}, ${y1}} to {0, 0} is valid`
        : `{${x1}, ${y1}} to {0, 0} is invalid`);
    console.log(Number.isInteger(result(x2, y2))
        ? `{${x2}, ${y2}} to {0, 0} is valid`
        : `{${x2}, ${y2}} to {0, 0} is invalid`);
 
    console.log(Number.isInteger(Math.sqrt((x2-x1)**2 + (y2-y1)**2))
        ? `{${x1}, ${y1}} to {${x2}, ${y2}} is valid`
        : `{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
 
 
    function result(x, y) {
        return Math.sqrt(x ** 2 + y ** 2);
    }
}

solve(2, 1, 1, 1);