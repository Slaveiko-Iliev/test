function solve(name, lastName, hairColor) {
    let person = {
        name,
        lastName,
        hairColor,
    }

    const personJson = JSON.stringify(person);

    console.log(personJson);
}

solve('George', 'Jones', 'Brown');