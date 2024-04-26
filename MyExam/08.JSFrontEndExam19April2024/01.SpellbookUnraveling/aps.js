function solve(input) {
    let magicWord = input[0];


    for (let i = 1; i < input.length; i++) {
        const commandInfo = input[i].split('!');
        const command = commandInfo[0];

        if (command !== 'End') {
            let tempWordAsArray = [];

            switch (command) {
                case 'RemoveEven':
                    tempWordAsArray = magicWord.split('');

                    for (let i = 1; i < tempWordAsArray.length; i+=2) {
                        tempWordAsArray[i] = '';
                    }

                    magicWord = tempWordAsArray.join('');
                    console.log(magicWord);
                    break;
            
                case 'TakePart':
                    magicWord = magicWord.substring(commandInfo[1], commandInfo[2]);
                    console.log(magicWord);
                    break;

                case 'Reverse':
                    const substring = commandInfo[1];
                    if (magicWord.includes(substring)) {
                        const reversedSubstring = substring.split('').reverse().join('');
                        magicWord = magicWord.replace(substring, '').concat('', reversedSubstring);
                        console.log(magicWord);

                    } else {
                        console.log('Error');
                    }
                    break;
                
            }
            
        }
        
    }

    console.log(`The concealed spell is: ${magicWord}`);
}

solve(["asAsl2adkda2mdaczsa", 
"RemoveEven",
"TakePart!1!9",
"Reverse!maz",
"End"]);