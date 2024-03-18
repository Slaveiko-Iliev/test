function solve(firstCharacter, secondCharacter) {
    // Find the start character
    const [start, end] = getSortedCharacters(firstCharacter, secondCharacter);

    // Iterate from start to end
    const result = getCharactersBetween(start, end);

    console.log(result.join(' '));
}

function getSortedCharacters(...characters) {
    characters.sort();

    return characters;
}

function getCharactersBetween(start, end) {
    let characters = [];

    for (let i = start.charCodeAt(0) + 1; i < end.charCodeAt(0); i++) {
        characters.push(String.fromCharCode(i));
    }

    return characters;
}

solve('C',
    '#'
)
