function solve(jsonInput) {
    let person = JSON.parse(jsonInput);
    Object.keys(person).forEach(key => {
        console.log(`${key}: ${person[key]}`);
    });
}

solve('{"name": "George", "age": 40, "town": "Sofia"}');