function solve(words, text) {
    let wordsAsArray = words.split(', ');

    for (const word of wordsAsArray) {
        let currentPurposeInText = ` ${'*'.repeat(word.length)} `;
        let wordForReplace =  `${'*'.repeat(word.length)}`;

        while (text.includes(currentPurposeInText)) {
            text = text.replace(wordForReplace, word);
            
        }
    }

    
    console.log (text);
}
 
// function solve(words, text) {
//     let wordsAsArray = words.split(', ');

//     for (const word of wordsAsArray) {
//         let currentPurposeInText = ` ${'*'.repeat(word.length)} `;
//         let wordForReplace =  `${'*'.repeat(word.length)}`;

//         while (text.includes(currentPurposeInText)) {
//             text = text.replace(wordForReplace, word);
            
//         }
//     }

    
//     console.log (text);
// }

solve ('great',
'softuni is ***** place for learning new programming languages'
);
solve ('great, learning',
'softuni is ***** place for ******** new programming languages'
);