function solve(number, power) {
    console.log(mathPower(number, power));

    function mathPower(number, power) {
        let result = 1;
    
        for (let i = 0; i < power; i++) {
            result *= number
    
        }
    
        return result;
    }
}

solve(2,8);
