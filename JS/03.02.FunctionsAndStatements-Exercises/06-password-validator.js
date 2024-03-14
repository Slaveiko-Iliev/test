function solve(input) {
    let checkCount = 0;
    if(checkLength(input)){
        checkCount ++;
    }
    if(checkOnlyLettersAndDigits(input)){
        checkCount ++;
    }
    if(checkIfAtLeastTwoDigits(input)){
        checkCount ++;
    }

    if (checkCount === 3){
        console.log(`Password is valid`);
    }

    function checkLength(input) {
        if (input.length >= 6 && input.length <= 10){
            return true;
        } else {
            console.log(`Password must be between 6 and 10 characters`);
        }
    }
    
    function checkOnlyLettersAndDigits(input) {
        let isOnlyLettersAndDigits = true;
    
        if (input.match(/[^a-zA-Z1-9]/g)){
            console.log(`Password must consist only of letters and digits`);
        } else {
            return true;
        }
    }
    
    function checkIfAtLeastTwoDigits(input) {
        if (input.match(/[1-9]{2,}/g)){
            return true;
        } else {
            console.log(`Password must have at least 2 digits`);
        }
    }
}



solve(`logIn`);
solve(`MyPass123`);
solve('Pa$s$s');