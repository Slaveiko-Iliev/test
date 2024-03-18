// function calculateFactorial(num) {
//     if (num == 0) 
//         return 1;
//     else {
//         return (num * calculateFactorial(num - 1));
//     }
//   }

function solve(numOne, numTwo) {
    function calculateFactorial(num) {
        if (num == 0) 
            return 1;
        else {
            return (num * calculateFactorial(num - 1));
        }
      }
      
    const result = calculateFactorial(numOne) / calculateFactorial(numTwo);

    console.log(result.toFixed(2));
}

solve (5, 2);
solve (6, 2);