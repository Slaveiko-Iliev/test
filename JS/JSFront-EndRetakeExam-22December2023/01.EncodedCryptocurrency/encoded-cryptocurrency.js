function solve(input) {
    let message = input.shift();

    let commandInfo = input.shift();

    while (commandInfo !== 'Buy') {
        const [command, substring, replacement] = commandInfo.split('?');
        let currentMessage = '';
        switch (command) {
            case 'TakeEven':
                const takeEven = (message) => message.split('').filter((_, i) => i%2 === 0).join('');
                // for (let j = 0; j < message.length; j++) {
                //     if (j % 2 === 0) {
                //         currentMessage += message[j];
                //     }
                // }
                message = takeEven(message);
                console.log(message);
                break; 
            
            case "ChangeAll":
                currentMessage = message;
                while (currentMessage.includes(substring)) {
                    currentMessage = currentMessage.replace(substring, replacement);
                }
                message = currentMessage;
                console.log(message);
                break;

            case 'Reverse':
                if (!message.includes(substring)) {
                    console.log('error');
                }    else {
                    message = message.replace(substring, '');
                    message += substring.split('').reverse().join('');
                    console.log(message);
                }
                break;
              
        }
        commandInfo = input.shift();
    }

    console.log(`The cryptocurrency is: ${message}`);

}

solve(["PZDfA2PkAsakhnefZ7aZ", 
"TakeEven",
"TakeEven",
"TakeEven",
"ChangeAll?Z?X",
"ChangeAll?A?R",
"Reverse?PRX",
"Buy"]);