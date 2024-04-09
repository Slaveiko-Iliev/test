function attachEventsListeners() {
    const converter = {
        'km': 1000,
        'm': 1,
        'cm': 0.01,
        'mm': 0.001,
        'mi': 1609.34,
        'yrd': 0.9144,
        'ft': 0.3048,
        'in': 0.0254,
    }
    
    const inputDistanceElement = document.getElementById('inputDistance');
    const inputUnitsElement = document.getElementById('inputUnits');
    const convertButtonElement = document.getElementById('convert');
    const outputDistanceElement = document.getElementById('outputDistance');
    const outputUnitsElement = document.getElementById('outputUnits');

    convertButtonElement.addEventListener('click', () => {
        let currentValueInMeters = Number(inputDistanceElement.value) * converter[inputUnitsElement.value];
        console.log(currentValueInMeters);
        outputDistanceElement.value = currentValueInMeters / converter[outputUnitsElement.value];
        console.log(outputDistanceElement.value);
    });

}