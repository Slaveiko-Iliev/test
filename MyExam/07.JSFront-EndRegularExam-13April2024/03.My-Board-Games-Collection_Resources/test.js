const myButton = document.createElement('button');
myButton.disabled = disabled;

if (myButton.getAttribute('disabled')) {
    console.log("Бутонът е деактивиран!");
} else {
    console.log("Бутонът не е деактивиран!");
}