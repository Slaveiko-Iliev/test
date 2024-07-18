class Person {
    age = null;
    type = 'Employee';

    constructor(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    greet(to) {
        console.log(`${this.firstName} says hello to ${to.firstName}`);
    }
}

const firstPerson = new Person('Pesho', 'Ivanov');
const secondPerson = new Person('Gosho', 'Petkov');

console.log(firstPerson instanceof Person);

console.log(firstPerson);
console.log(secondPerson);

firstPerson.greet(secondPerson);
secondPerson.greet(firstPerson);

