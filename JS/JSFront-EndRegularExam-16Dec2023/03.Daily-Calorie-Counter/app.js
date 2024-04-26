const baseUrl = `http://localhost:3030/jsonstore/tasks`;
const buttonLoadMealsElement = document.getElementById('load-meals');
const buttonAddMealElement = document.getElementById('add-meal');
const buttonEditMealElement = document.getElementById('edit-meal');
const inputFoodElement = document.getElementById('food');
const inputTimeElement = document.getElementById('time');
const inputCaloriesElement = document.getElementById('calories');
const mealsListElement = document.getElementById('list');
const formElement = document.getElementById('form');

buttonLoadMealsElement.addEventListener(('click'), loadMeals);
buttonAddMealElement.addEventListener(('click'), addMeal);
buttonEditMealElement.addEventListener(('click'), (e) => editMeal(e));


function loadMeals() {
    mealsListElement.innerHTML = '';
    const newMealFragment = document.createDocumentFragment();

    fetch(`${baseUrl}`)
    .then(responseMeals => responseMeals.json())
    .then(meals => {
        Object
            .values(meals)
            .forEach(meal => {
                const divMealElement = createDivMealElement(meal);
                newMealFragment.appendChild(divMealElement);
            })

        mealsListElement.appendChild(newMealFragment);
        buttonEditMealElement.setAttribute('disabled', 'disabled');
    })
    .catch(error => console.log('Something went wrong'));
}

function createDivMealElement(meal) {
    const buttonChangeElement = document.createElement('button');
    buttonChangeElement.classList.add('change-meal');
    buttonChangeElement.textContent = 'Change';

    const buttonDeleteElement = document.createElement('button');
    buttonDeleteElement.classList.add('delete-meal');
    buttonDeleteElement.textContent = 'Delete';

    const mealButtonsElement = document.createElement('div');
    mealButtonsElement.id = 'meal-buttons';
    mealButtonsElement.appendChild(buttonChangeElement);
    mealButtonsElement.appendChild(buttonDeleteElement);

    const h2FoodElement = document.createElement('h2');
    h2FoodElement.textContent = meal.food;
    const h3TimeElement = document.createElement('h3');
    h3TimeElement.textContent = meal.time;
    const h3CaloriesElement = document.createElement('h3');
    h3CaloriesElement.textContent = meal.calories;

    const divMealElement = document.createElement('div');
    divMealElement.classList.add('meal');
    
    divMealElement.appendChild(h2FoodElement);
    divMealElement.appendChild(h3TimeElement);
    divMealElement.appendChild(h3CaloriesElement);
    divMealElement.appendChild(mealButtonsElement);
    divMealElement.setAttribute('data-id', meal._id);

    buttonChangeElement.addEventListener(('click'), () => {
        inputFoodElement.value = h2FoodElement.textContent;
        inputTimeElement.value = h3TimeElement.textContent;
        inputCaloriesElement.value = h3CaloriesElement.textContent;

        
        formElement.setAttribute('data-id', meal._id);

        buttonChangeElement.parentElement.parentElement.remove();

        buttonEditMealElement.removeAttribute('disabled');
        buttonAddMealElement.setAttribute('disabled', 'disabled');
    });

    buttonDeleteElement.addEventListener(('click'), () => {
    fetch(`${baseUrl}/${meal._id}`, {
            method: 'DELETE'
        })
            .then(res => {
                if (!res.ok){
                    return;
                }
                buttonDeleteElement.parentElement.parentElement.remove();
                loadMeals();
            })
            .catch(err => console.log(err));
    });

    return divMealElement
}

function addMeal() {
    const newMeal = getMealInput();

    fetch(baseUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(newMeal)
    })
        .then(res => {
            if (!res.ok) {
                return;
            }
            clearMealInput();
            loadMeals();
        })
        .catch(err => console.log(err));

    
}

function editMeal(e) {
    const mealForEdit = getMealInput();

    const currentId = formElement.getAttribute('data-id');

    fetch(`${baseUrl}/${currentId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({_id: currentId, ...mealForEdit})
    })
        .then(res => {
            if (!res.ok){
                return
            }

            formElement.removeAttribute('data-id');
            loadMeals();
            clearMealInput();
            buttonEditMealElement.setAttribute('disabled', 'disabled');
            buttonAddMealElement.removeAttribute('disabled');
        })
        .catch(err => console.log(err));
}

function getMealInput() {
    return {
        'food': inputFoodElement.value,
        'time': inputTimeElement.value,
        'calories': inputCaloriesElement.value,
    }
}

function clearMealInput() {
    inputFoodElement.value = '';
    inputTimeElement.value = '';
    inputCaloriesElement.value = '';
}