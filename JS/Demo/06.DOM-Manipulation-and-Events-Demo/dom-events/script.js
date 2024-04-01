const decrementButtonElement = document.getElementById('decrement-button');
const countElement = document.getElementById('count');
const resetButtonElement = document.getElementById('reset-button');

// Using DOM event handler – preferred method
const eventListener = (event) => {
    countElement.textContent = 0;
};

resetButtonElement.addEventListener('click', eventListener);

// Using DOM element properties
decrementButtonElement.onclick = function(event) {
    countElement.textContent = Number(countElement.textContent) - 1;
}

//With HTML Attributes
function onIncrement(event) {
    countElement.textContent = Number(countElement.textContent) + 1;
}

// Remove event listener for rest after 10 seconds
setTimeout(() => {
    resetButtonElement.removeEventListener('click', eventListener);
}, 10000);

// Use input event
const inputNumberElement = document.getElementById('number');
inputNumberElement.addEventListener('input', (event) => {
    countElement.textContent = event.target.value;
});

// Multiple listeners
resetButtonElement.addEventListener('click', (event) => {
    inputNumberElement.value = '';
});
