let person = {
    name: 'Pesho',
    age: 20
}

// Convert JS Object to JSON
const data = JSON.stringify(person);

console.log(data); // IT's a string

// Convert from JSON tor JS object
const originalOBject = JSON.parse(data);
console.log(originalOBject);
