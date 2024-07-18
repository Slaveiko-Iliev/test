// Create an object
let person = { name: 'Pesho', age: 20 };

// Create an object with non classis identifier
let person2 = { 'full-name': 'Ivan Ivanov' };

// Use dot syntax to get property value
console.log(person.name);
// console.log(person2.full-name);

// Use bracket syntax to get property value
console.log(person['age']);
console.log(person2['full-name']);

// Create an empty object and dynamically add values
const animal = {};

// Add with dot syntax
animal.name = 'Navcho';

// Add with bracket syntax
animal['min-weight'] = 2;

// Add dynamic name property
const propName = 'type';
animal[propName] = 'Cat';

console.log(animal);

// Add dynamic name property in the literal
const dynamicPropName = 'fullName';
const person3 = {
    [dynamicPropName]: 'Ivan Ivanov',
}
console.log(person3);

// Multiline object literal (over 2 properties)
let firstName = 'Ivo';
let lastName = 'Papazov';
let age = 24;
let height = 182;

const personInfo = {
    firstName: firstName,
    lastName: lastName,
    age: age,
};

// Object literal with shorthand syntax
const shortPersonInfo = {
    firstName,
    lastName,
    age,
    height,
}

// Get undefined property
console.log(animal.nonExistent);

// delete entry
delete shortPersonInfo.firstName;
console.log(shortPersonInfo);

// Object destructuring assignment
let person4 = { name: 'Gosho', age: 21 };
const { age: personAge, name } = person4;

// Object destructuring assignment with rest
const { lastName: surName, ...restPersonalInfo} = shortPersonInfo;
console.log(surName);
console.log(restPersonalInfo);
