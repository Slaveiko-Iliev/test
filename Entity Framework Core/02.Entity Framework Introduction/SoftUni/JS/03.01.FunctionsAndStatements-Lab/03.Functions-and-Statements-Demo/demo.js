// Function declaration
function log(text) {
    console.log(text);
}

// Function expression
const log2 = function (text) {
    console.log(text);
}

// Arrow function
const log3 = (text) => console.log(text);

// Function invokation
log('Some text');
log2('Some text 2');
log3('Some text 3');

// Default return value
const defaultReturnValue = log('Default Value');
console.log(defaultReturnValue);

// Invoke function from another function
function masterLog(text) {
    log(`1 - ${text}`);
    log2(`2 - ${text}`);
    log3(`3 - ${text}`);
}

masterLog('Ivo');


// Recursion
function countDown(x) {
    console.log(x);
    if (x > 0) {
        countDown(x - 1);
    }
}

countDown(10);

// Return value
function isValid(index, arr) {
    return Number.isInteger(index) && index >= 0 && index < arr.length;
}
