function solve (text, wordToReplace) {
    let censored = text.replace(wordToReplace, '*'.repeat(wordToReplace.length));
    
    while (censored.includes(wordToReplace)) {
        censored = censored.replace(wordToReplace, '*'.repeat(wordToReplace.length));
    }

    console.log (censored);
}

solve ('A small small sentence with some words', 'small');
solve ('Find the hidden word', 'hidden');