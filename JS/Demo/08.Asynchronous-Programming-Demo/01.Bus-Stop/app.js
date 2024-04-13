function getInfo() {
    const baseUrl = 'http://localhost:3030/jsonstore/bus/businfo';

    const stopIdElement = document.getElementById('stopId');
    const stopNameElement = document.getElementById('stopName');
    const busesElement = document.getElementById('buses');

    const stopId = stopIdElement.value;
    fetch(`${baseUrl}/${stopId}`)
        .then(res => res.json())
        .then(data => {
            console.log(data);
            stopNameElement.textContent = data.name

            for (const busId in data.buses) {
                const liElement = document.createElement('li');
                liElement.textContent = `Bus ${busId} arrives in ${data.buses[busId]} minutes`
                busesElement.appendChild(liElement);
            }
        })
        .catch(() => {
            stopNameElement.textContent = 'Error'
        });

}
