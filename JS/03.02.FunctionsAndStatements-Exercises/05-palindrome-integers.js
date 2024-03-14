function solve(numbersArray) {
    for (const number of numbersArray) {
        
        console.log (isPalindrome(makeArrayFromNumber(number)));
    }

    function makeArrayFromNumber(number) {
        const numberAsArray = number
            .toString()
            .split('');
    
        return numberAsArray;
    }
    
    function isPalindrome(numbers) {
        let isTrue = true;
        for (let i = 0; i < numbers.length / 2; i++) {
            if (numbers[i] !== numbers[numbers.length - 1 - i]){
                isTrue = !isTrue;
                break;
            }
            
        }
    
        return isTrue;
    }
}



solve([123,323,421,121]);
solve([32,2,232,1010]);