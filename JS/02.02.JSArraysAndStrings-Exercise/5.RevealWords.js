

// function solve(words, text) {
//     let wordsAsArray = words.split(', ').sort((a,b) => b.length - a.length);
    
//     for (const word of wordsAsArray) {
//         text = text.replace('*'.repeat(word.length), word)
//     }

    
//     console.log (text);
// }

function solve(words, text) {
    let wordsAsArray = words.split(', ');
    let textAsArray = text.split(' ');
    
    const result = textAsArray
        .map(element =>
            element.includes('*') 
            ? wordsAsArray.find(word => word.length === element.length)
            : element)
        .join(' ');
    
    console.log (result);
}
 

solve ('great',
'softuni is ***** place for learning new programming languages'
);
solve ('great, learning',
'softuni is ***** place for ******** new programming languages'
);