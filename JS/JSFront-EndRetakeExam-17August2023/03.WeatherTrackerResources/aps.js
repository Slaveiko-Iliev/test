const baseUrl = `http://localhost:3030/jsonstore/tasks`;

const listHistoryElement = document.getElementById('list');
const formElement = document.getElementById('form');
const buttonLoadHistoryElement = document.getElementById('load-history');
const buttonAddWeatherElement = document.getElementById('add-weather');
const buttonEditWeatherElement = document.getElementById('edit-weather');
const inputLocationElement = document.getElementById('location');
const inputDateElement = document.getElementById('date');
const inputTemperatureElement = document.getElementById('temperature');

buttonLoadHistoryElement.addEventListener(('click'), loadHistory);
buttonAddWeatherElement.addEventListener(('click'), addForecast);
buttonEditWeatherElement.addEventListener(('click'), (e) => editWeather(e));

function loadHistory() {
    listHistoryElement.innerHTML = '';
    const listFragment = document.createDocumentFragment();

    fetch(`${baseUrl}`)
    .then(response => response.json())
    .then(data => {
        Object
            .values(data)
            .forEach(forecast => {
                const currentForecast = createDivContainer(forecast);
                listFragment.appendChild(currentForecast);
            });
        
        listHistoryElement.appendChild(listFragment);
    })
    .catch(error => console.log('Something load wrong'));

}

function createDivContainer(forecast) {
    const buttonDeleteElement = document.createElement('button');
    buttonDeleteElement.classList.add('delete-btn');
    buttonDeleteElement.textContent = 'Delete';

    const buttonChangeElement = document.createElement('button');
    buttonChangeElement.classList.add('delete-btn');
    buttonChangeElement.textContent = 'Change';

    const divButtonsElement = document.createElement('div');
    divButtonsElement.classList.add('buttons-container');

    divButtonsElement.appendChild(buttonChangeElement);
    divButtonsElement.appendChild(buttonDeleteElement);

    const h2LocationElement = document.createElement('h2');
    h2LocationElement.textContent = forecast.location;
    const h3DateElement = document.createElement('h3');
    h3DateElement.textContent = forecast.date;
    const h3TemperatureElement = document.createElement('h3');
    h3TemperatureElement.textContent = forecast.temperature;

    const divContainerElement = document.createElement('div');
    divContainerElement.classList.add('container');
    divContainerElement.setAttribute('data-id', forecast._id);

    divContainerElement.appendChild(h2LocationElement);
    divContainerElement.appendChild(h3DateElement);
    divContainerElement.appendChild(h3TemperatureElement);
    divContainerElement.appendChild(divButtonsElement);

    buttonChangeElement.addEventListener(('click'), () => {
        inputLocationElement.value = h2LocationElement.textContent;
        inputDateElement.value = h3DateElement.textContent;
        inputTemperatureElement.value = h3TemperatureElement.textContent;

        formElement.setAttribute('data-id', forecast._id);

        divContainerElement.remove();

        buttonEditWeatherElement.removeAttribute('disabled');
        buttonAddWeatherElement.setAttribute('disabled', 'disabled');
    });


    buttonDeleteElement.addEventListener(('click'), () => {
        fetch(`${baseUrl}/${forecast._id}`, {
                method: 'DELETE'
            })
                .then(res => {
                    if (!res.ok){
                        return;
                    }
                    buttonDeleteElement.parentElement.parentElement.remove();
                    loadHistory();
                })
                .catch(err => console.log('Something delete wrong'));
        });

    
                return divContainerElement;
}

function addForecast() {
    const newForecast = getWeatherInput();

    fetch(baseUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(newForecast)
    })
        .then(res => {
            if (!res.ok) {
                return;
            }
            loadHistory();
            clearWeatherInput();
        })
        .catch(err => console.log('Something add wrong'));
}

function editWeather(e) {
    
    const id = formElement.getAttribute('data-id');

    fetch(`${baseUrl}/${id}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({...getWeatherInput(), _id: id})
    })
        .then(res => {
            if (!res.ok) {
                return
            }
            clearWeatherInput();
            formElement.removeAttribute('data-id');
            buttonEditWeatherElement.setAttribute("disabled", "disabled");
            buttonAddWeatherElement.removeAttribute("disabled");
            loadHistory();
        })
        .catch(err => console.log('Something edit wrong'));
}

function getWeatherInput() {
    return {
        'location': inputLocationElement.value,
        'date': inputDateElement.value,
        'temperature': inputTemperatureElement.value,
    }
}

function clearWeatherInput() {
    inputLocationElement.value = '';
    inputDateElement.value = '';
    inputTemperatureElement.value = '';
}

