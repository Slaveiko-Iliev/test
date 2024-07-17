function solve(firstName, lastName, hairColor) {
    const info = {
        name: firstName,
        lastName,
        hairColor,
    };

    const jsonData = JSON.stringify(info);

    console.log(jsonData);
}

solve('George', 'Jones', 'Brown');
