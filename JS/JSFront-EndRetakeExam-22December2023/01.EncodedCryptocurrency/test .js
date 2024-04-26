let str = "This is a test!";

const [even] = [...str].reduce((char,i) => (char[i%2].push(char)), [[]])

console.log(odd.join(''))
console.log(even.join(''))