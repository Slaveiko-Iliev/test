function solve(text) {
    let startIndex = -1;
    let endIndex = -1;
    let pascalArray = [];

    function isUpper(char) {
        return char === char.toUpperCase();
    }

    for (let i = 0; i < text.length; i++) {
        if (startIndex === -1 && isUpper(text[i])){
            startIndex = i;
            
        } else if (startIndex !== -1 && isUpper(text[i])){
            endIndex = i;
            pascalArray.push(text.substring(startIndex, endIndex));
            
            startIndex = i;
            if (i === text.length - 1) {
                pascalArray.push(text.substring(startIndex));
            }
        } else if (startIndex !== -1 && i === text.length - 1){
            pascalArray.push(text.substring(startIndex));
        }
    }

    console.log (pascalArray.join(', '));
}

// solve ('SplitMeIfYouCanHaHaYouCantOrYouCanT');
// solve ('HoldTheDoor');
// solve ('ThisIsSoAnnoyingToDo');
solve ('DT');