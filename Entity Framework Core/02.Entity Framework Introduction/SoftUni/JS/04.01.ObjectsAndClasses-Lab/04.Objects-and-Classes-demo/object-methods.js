// Define method in object literal
const cat = {
    name: 'Navcho',
    breed: 'Persian',
    age: 9,
    grades: [5, 6, 5, 6, 5],
    owner: {
        name: 'Ivo',
        age: 24,
    },
    // Function expression value
    makeSound: function() {
        console.log('Meao...');
    },
    // Arrow function
    sleep: () => console.log('zzzZzzz...')
}

// Call method
let methodName = 'makeSound';
cat.makeSound(); // Most popular choice
cat['makeSound']();
cat[methodName]();

// Add method dynamically
cat.eat = function() {
    console.log('Omnomnomnom...');
}
cat.eat2 = () => console.log('Omnomnomnom2');

cat.eat();

// Use method notaion syntax
const dog = {
    name: 'Sharo',
    breed: 'Ulichna Prevyzhodna',
    makeSound() {
        console.log('Wof wof...');
    },
    ownerName:'Pesho',
}

// Get all property names of an object
const propertyNames = Object.keys(cat);
console.log(propertyNames);


// Get all property values of an object
const propertyValues = Object.values(cat);
console.log(propertyValues);

// Get object key value pairs
const simpleObejct = {
    name: 'Pesho',
    age: 20,
};
const entries = Object.entries(simpleObejct);
console.log(entries);

// Reveser entries
const originalSimpleObejct = Object.fromEntries(entries);
console.log(originalSimpleObejct);

// Check for method and call
cat.makeSound123 && cat.makeSound();
