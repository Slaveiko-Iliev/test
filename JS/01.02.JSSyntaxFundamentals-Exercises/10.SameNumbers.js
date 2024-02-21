function solve(number) {

    let currentDigit = null;
    let isTrue = true;
    let sum = 0;

    while (number > 0) {

        let nextDigit = number%10;

       if (currentDigit != null && currentDigit != nextDigit) {
                isTrue = !isTrue;
            } 
        
        currentDigit = nextDigit;
        sum += nextDigit;
        number = Math.floor(number / 10);
    }

    console.log(isTrue);
    console.log(sum);
}

solve(2222222);
solve(1234);