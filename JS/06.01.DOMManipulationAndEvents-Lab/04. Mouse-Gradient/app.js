function attachGradientEvents() {
    const gradientElement = document.getElementById('gradient');
    const resultElement = document.getElementById('result');

    gradientElement.addEventListener('mousemove', (event) => {
        const currentWidth = event.offsetX;
        const elementWidth = event.target.clientWidth;
        const progres = Math.floor((currentWidth/elementWidth)*100);
        resultElement.textContent = `${progres}%`;
    });
}