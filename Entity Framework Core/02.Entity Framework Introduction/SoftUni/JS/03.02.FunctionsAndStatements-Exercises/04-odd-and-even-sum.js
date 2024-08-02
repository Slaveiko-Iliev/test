function findOddAndEvenSum(number) {
    let oddSum = 0;
    let evenSum = 0;

    while (number > 0) {
        const lastDigit = number % 10;

        if (lastDigit % 2 === 0){
            evenSum += lastDigit;
        } else {
            oddSum += lastDigit;
        }

        number = Math.floor(number /= 10);
    }

    console.log (`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
};

findOddAndEvenSum(1000435);
findOddAndEvenSum(3495892137259234);