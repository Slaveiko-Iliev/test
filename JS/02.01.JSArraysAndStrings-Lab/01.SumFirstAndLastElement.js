function solve (elements) {
    console.log (elements.shift() + elements.pop());
}

//Горното може да е проблем, ако се подаде едно число

// function solve (elements) {
//     console.log (elements[0] + elements[elements.length - 1]);
// }

solve ([20, 30, 40]);
solve ([10, 17, 22, 33]);
solve ([11, 58, 69]);
