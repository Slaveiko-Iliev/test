const baseUrl = `http://localhost:3030/jsonstore/records`;

const buttonLoadRecordsElement = document.getElementById('load-records');
const buttonEditRecordsElement = document.getElementById('edit-record');
const buttonAddRecordElement = document.getElementById('add-record');
const inputPNameElement = document.getElementById('p-name');
const inputStepsElement = document.getElementById('steps');
const inputCaloriesElement = document.getElementById('calories');
const ulListElement = document.getElementById('list');
const divFormElement = document.getElementById('form');

buttonLoadRecordsElement.addEventListener(('click'), loadRecords);
buttonAddRecordElement.addEventListener(('click'), addRecord);
buttonEditRecordsElement.addEventListener(('click'), editRecord);

function loadRecords() {
    ulListElement.innerHTML = '';
    const newRecordsFragment = document.createDocumentFragment();

    fetch(`${baseUrl}`)
    .then(responseRecords => responseRecords.json())
    .then(records => {
        Object
            .values(records)
            .forEach(record => {
                const liRecordElement = createDivMealElement(record);
                newRecordsFragment.appendChild(liRecordElement);
            })

        ulListElement.appendChild(newRecordsFragment);
        buttonEditRecordsElement.setAttribute('disabled', 'disabled');
    })
    .catch(error => console.log('Something went wrong'));
}

function createDivMealElement(record) {
    const buttonChangeElement = document.createElement('button');
    buttonChangeElement.classList.add('change-btn');
    buttonChangeElement.textContent = 'Change';
  
    const buttonDeleteElement = document.createElement('button');
    buttonDeleteElement.classList.add('delete-btn');
    buttonDeleteElement.textContent = 'Delete';

    const divBtnWrapperElement = document.createElement('div');
    divBtnWrapperElement.classList.add('btn-wrapper');
    divBtnWrapperElement.appendChild(buttonChangeElement);
    divBtnWrapperElement.appendChild(buttonDeleteElement);

    const pNameElement = document.createElement('p');
    pNameElement.textContent = record.name;
    const pStepsElement = document.createElement('p');
    pStepsElement.textContent = record.steps;
    const pCaloriesElement = document.createElement('p');
    pCaloriesElement.textContent = record.calories;

    const divInfoElement = document.createElement('div');
    divInfoElement.classList.add('info');
    divInfoElement.appendChild(pNameElement);
    divInfoElement.appendChild(pStepsElement);
    divInfoElement.appendChild(pCaloriesElement);

    const liRecordElement = document.createElement('li');
    liRecordElement.setAttribute('data-id', record._id);
    liRecordElement.classList.add('record');
    liRecordElement.appendChild(divInfoElement);
    liRecordElement.appendChild(divBtnWrapperElement);

    buttonChangeElement.addEventListener(('click'), () => {
        const buttonChangeParentLi = buttonChangeElement.parentElement.parentElement;
        const currentId = buttonChangeParentLi.getAttribute('data-id');

        inputPNameElement.value = pNameElement.textContent;
        inputStepsElement.value = pStepsElement.textContent;
        inputCaloriesElement.value = pCaloriesElement.textContent;

        divFormElement.setAttribute('data-id', currentId);
        buttonEditRecordsElement.removeAttribute('disabled');
        buttonAddRecordElement.setAttribute('disabled','disabled');
    });

    buttonDeleteElement.addEventListener(('click'), () => {
        const buttonDeleteParentLi = buttonChangeElement.parentElement.parentElement;
        const currentId = buttonDeleteParentLi.getAttribute('data-id');

        fetch(`${baseUrl}/${currentId}`, {
            method: 'DELETE'
        })
            .then(res => {
                if (!res.ok){
                    return;
                }
                buttonDeleteElement.parentElement.parentElement.remove();
                loadRecords();
            })
            .catch(err => console.log(err));
    });

    return liRecordElement;
}

function addRecord() {
    const newRecord = readInputs();

    fetch(baseUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(newRecord)
    })
        .then(res => {
            if (!res.ok) {
                return;
            }
            clearInputs();
            loadRecords();
        })
        .catch(err => console.log(err));
}

function editRecord(e) {
    const recordForEdit = readInputs();

    const currentId = divFormElement.getAttribute('data-id');

    fetch(`${baseUrl}/${currentId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({_id: currentId, ...recordForEdit})
    })
        .then(res => {
            if (!res.ok){
                return
            }

            clearInputs();
            loadRecords();
            divFormElement.removeAttribute('data-id');
            buttonEditRecordsElement.setAttribute('disabled', 'disabled');
            buttonAddRecordElement.removeAttribute('disabled');
        })
        .catch(err => console.log(err));
}

function clearInputs() {
    inputPNameElement.value = '';
    inputStepsElement.value = '';
    inputCaloriesElement.value = '';
}

function readInputs() {
    const record = {
        'name': inputPNameElement.value,
        'steps': inputStepsElement.value,
        'calories': inputCaloriesElement.value,
    }

    return record;
}