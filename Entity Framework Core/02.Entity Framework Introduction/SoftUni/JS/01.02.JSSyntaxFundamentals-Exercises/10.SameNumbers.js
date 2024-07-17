function solve(number) {

    let currentDigit = null;
    let isTrue = true;
    let sum = 0;

    while (Math.abs(number) > 0) {

        let nextDigit = Math.abs(number)%10;

       if (currentDigit != null && currentDigit != nextDigit) {
                if (isTrue) {
                    isTrue = !isTrue;
                }
            } 
        
        currentDigit = nextDigit;
        sum += nextDigit;
        number = Math.floor(Math.abs(number) / 10);
    }

    console.log(isTrue);
    console.log(sum);
}

// solve(2222222);
// solve(1234);
// solve(0);
solve(-369);