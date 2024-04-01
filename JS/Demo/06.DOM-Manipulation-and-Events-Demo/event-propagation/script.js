const orangeElement = document.querySelector('.orange');
const greenElement = document.querySelector('.green');
const yellowElement = document.querySelector('.yellow');

orangeElement.addEventListener('click', () => {
    console.log('Orange clicked');
}, { capture: false });

greenElement.addEventListener('click', (event) => {
    console.log('Green clicked');
}, { capture: true });

yellowElement.addEventListener('click', (event) => {
    event.stopPropagation();
    console.log('Yellow clicked');
}, { capture: false });
