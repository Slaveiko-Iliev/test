function solve(input, wordToSearch) {
    let result = input
        .split(' ')
        .filter(element => element === wordToSearch)
        .length;

    console.log (result);
}

// function solve(input, wordToSearch) {
//     let countOfRepeat = 0;

//     let text = input.split(' ');

//     for (let i = 0; i < text.length; i++) {
//         if (text[i] === wordToSearch) {
//             countOfRepeat++;
//         }
//     }

//     console.log (countOfRepeat);
// }

solve ('This is a word and it also is a sentence',
'is'
);
solve ('softuni is great place for learning new programming languages',
'softuni'
);