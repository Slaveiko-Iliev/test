function solve(input) {
    const wordsToFind = input.shift().split(' ');
    let wordsList = [];

    for (const record of wordsToFind) {
        const currentWord = {
            word: record,
            count: 0,
        }

        for (const element of input) {
            if(element === record){
                currentWord.count ++;
            }
        }

        wordsList.push(currentWord);
    }

    wordsList.sort((a, b) => b.count - a.count).forEach(element => console.log(`${element.word} - ${element.count}`));
}

solve([
    'this sentence', 
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ]
    );

    solve([
        'is the', 
        'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence']
        );