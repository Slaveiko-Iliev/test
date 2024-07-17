function findSmallestNumber(a, b, c) {
    const result = Math.min(a, b, c);
    
    console.log (result);
}


function findSmallestNumber2(...numbers) {
    const result = Math.min(...numbers);
    
    console.log(result);
}

 

findSmallestNumber2(2, 5, 3);
findSmallestNumber(600,
    342,
    123);
findSmallestNumber(25,
    21,
    4);
findSmallestNumber(2,
    2,
    2);