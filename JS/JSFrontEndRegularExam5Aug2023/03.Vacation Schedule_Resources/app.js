const baseUrl = `http://localhost:3030/jsonstore/tasks`;

const buttonLoadVacations = document.getElementById('load-vacations');
const buttonEditVacation = document.getElementById('edit-vacation');
const inputNameElement = document.getElementById('name');
const inputDateElement = document.getElementById('date');
const inputNumDaysElement = document.getElementById('num-days');
const listElement = document.getElementById('list');

buttonLoadVacations.addEventListener(('click'), loadVacations);

function loadVacations() {
    fetch(baseUrl)
    .then(response => response.json())
    .then(vacations => {
        listElement.innerHTML = '';
        const listFragment = document.createDocumentFragment();

        Object
            .values(vacations)
            .forEach(vacation => {
                listFragment.appendChild(createDivContainer(vacation));
            });

        listElement.appendChild(listFragment);
        buttonEditVacation.setAttribute('disabled', 'disabled');
    })
    .catch(error => console.log('Something load wrong'));
}

function createDivContainer(vacation) {
    const h2NameElement = document.createElement('h2');
    h2NameElement.textContent = vacation.name;
    const h3DateElement = document.createElement('h3');
    h3DateElement.textContent = vacation.date;
    const h3NumDaysElement = document.createElement('h3');
    h3NumDaysElement.textContent = vacation.days;

    const buttonChangeElement = document.createElement('button');
    buttonChangeElement.classList.add('change-btn');
    buttonChangeElement.textContent = 'Change';
    const buttonDoneElement = document.createElement('button');
    buttonDoneElement.classList.add('done-btn');
    buttonDoneElement.textContent = 'Done';

    const divContainerElement = document.createElement('div');
    divContainerElement.classList.add('container');
    divContainerElement.setAttribute('data-id', vacation._id);

    divContainerElement.appendChild(h2NameElement);
    divContainerElement.appendChild(h3DateElement);
    divContainerElement.appendChild(h3NumDaysElement);
    divContainerElement.appendChild(buttonChangeElement);
    divContainerElement.appendChild(buttonDoneElement);

    return divContainerElement;
}