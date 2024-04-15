window.addEventListener("load", solve);

function solve() {
    const addButtonElement = document.getElementById('add-btn');
    const tasklistElement = document.getElementById('task-list');
    const placeInputElement = document.getElementById('place');
    const actionInputElement = document.getElementById('action');
    const personInputElement = document.getElementById('person');
    
    addButtonElement.addEventListener(('click'), addTask);

    function addTask() {
        const newLiElement = document.createElement('li');
        newLiElement.classList.add('clean-task');

        if (placeInputElement.value !== ''
            && actionInputElement.value !== ''
            && personInputElement.value !== '') {
            
            
            const newArticleElement = document.createElement('artcle');

            const newPPlaceElement = document.createElement('p');
            newPPlaceElement.textContent = `Place:${placeInputElement.value}`;

            const newPActiionElement = document.createElement('p');
            newPActiionElement.textContent = `Action:${actionInputElement.value}`;

            const newPPersonElement = document.createElement('p');
            newPPersonElement.textContent = `Person:${personInputElement.value}`;

            newArticleElement.appendChild(newPPlaceElement);
            newArticleElement.appendChild(newPActiionElement);
            newArticleElement.appendChild(newPPersonElement);

            const newDivElement = document.createElement('div');
            newDivElement.classList.add('buttons');
            const newEditButtonElement = document.createElement('button');
            newEditButtonElement.classList.add('edit');
            newEditButtonElement.textContent = 'Edit';

            

            const newDoneButtonElement = document.createElement('button');
            newDoneButtonElement.classList.add('done');
            newDoneButtonElement.textContent = 'DOne';

            newDivElement.appendChild(newEditButtonElement);
            newDivElement.appendChild(newDoneButtonElement);


            newLiElement.appendChild(newArticleElement);
            newLiElement.appendChild(newDivElement);

            tasklistElement.appendChild(newLiElement);

            placeInputElement.value = '';
            actionInputElement.value = '';
            personInputElement.value = '';
            
            newEditButtonElement.addEventListener(('click'), () => {
                placeInputElement.value = newPPlaceElement.textContent.substring(6);
                actionInputElement.value = newPActiionElement.textContent.substring(7);
                personInputElement.value = newPPersonElement.textContent.substring(7);
            
                newEditButtonElement.parentElement.parentElement.remove();
            });

            newDoneButtonElement.addEventListener(('click'), () => {
                const currentLiElement = newDoneButtonElement.parentElement.parentElement;
                const doneListElement = document.getElementById('done-list');

                newDoneButtonElement.parentElement.remove();
                const deleteButtonElement = document.createElement('button');
                deleteButtonElement.classList.add('delete');
                deleteButtonElement.textContent = 'Delete';

                deleteButtonElement.addEventListener(('click'), ()=> {
                    deleteButtonElement.parentElement.remove();
                });

                currentLiElement.appendChild(deleteButtonElement);
                doneListElement.appendChild(currentLiElement);
            });
        }
    }
}

