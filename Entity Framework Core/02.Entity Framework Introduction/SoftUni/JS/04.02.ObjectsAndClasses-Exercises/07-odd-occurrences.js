function solve(input) {
    const words = input.toUpperCase().split(' ');
    let wordsCount = [];

    for (const word of words) {
        !wordsCount.includes(element => element[word]) ?
            wordsCount.push({word, count})
            : wordsCount[word] ++;
    }

    console.log(wordsCount);

    // for (const word in wordsCount) {
    //     if (wordsCount[word] % 2 !== 0){
    //         console.log(`${word} `);
    //     }
    // }
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#'); 