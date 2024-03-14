function solve(input) {
    let regEx = /#[a-zA-Z]+/gm;

    let arrayWithMatches = input.match(regEx);

    for (let i = 0; i < arrayWithMatches.length; i++) {
        arrayWithMatches[i] = arrayWithMatches[i].replace('#', '');
    }

    for (const match of arrayWithMatches) {
        console.log (match);
    }
}

solve ('Nowadays everyone uses # to tag a #special word in #socialMedia');
solve ('The symbol # is known #variously in English-speaking #regions as the #number sign');