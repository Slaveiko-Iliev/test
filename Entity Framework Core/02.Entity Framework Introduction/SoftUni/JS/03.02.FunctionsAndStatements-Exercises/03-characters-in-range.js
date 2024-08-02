function printRangeOfCharacters(ch1, ch2) {
    const valueOfCh1 = ch1.charCodeAt();
    const valueOfCh2 = ch2.charCodeAt();
    let startIndex = Math.min(valueOfCh1, valueOfCh2);
    let endIndex = Math.max(valueOfCh1, valueOfCh2);;
    let arrayOfChar = [];
            
    for (let i = startIndex + 1; i < endIndex; i++) {
        arrayOfChar.push(String.fromCharCode(i));
    }

    console.log (arrayOfChar.join(' '));
}

printRangeOfCharacters (`a`, `d`);
printRangeOfCharacters (`#`, `:`);
printRangeOfCharacters (`C`, `#`);