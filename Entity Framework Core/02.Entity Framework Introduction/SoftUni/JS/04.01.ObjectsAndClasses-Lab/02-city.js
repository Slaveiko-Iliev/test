function solve(inputObject) {
    const objectProperties = Object.entries(inputObject);
    objectProperties.forEach(object => console.log(`${object[0]} -> ${object[1]}`));
}

solve({
    name: "Plovdiv",
    area: 389,
    population: 1162358,
    country: "Bulgaria",
    postCode: "4000"
}
);