window.addEventListener("load", solve);

function solve() {
    const previewListElement = document.getElementById('preview-list');
    const inputExpenseElement = document.getElementById('expense');
    const inputAmountElement = document.getElementById('amount');
    const inputDateElement = document.getElementById('date');
    const addButtomElement = document.getElementById('add-btn');
    const expensesListElement = document.getElementById('expenses-list');
    const newDeleteButtonElement = document.querySelector('.delete');
    console.log(newDeleteButtonElement);

    newDeleteButtonElement.addEventListener(('click'), () => {
        window.location.reload();
    });
 
    addButtomElement.addEventListener(('click'), () => {
        const newLiElement = document.createElement('li');
        newLiElement.classList.add('expense-item');
        const newArticleElement = document.createElement('article');
        const newPTypeElement = document.createElement('p');
        newPTypeElement.textContent = `Type: ${inputExpenseElement.value}`;
        const newPAmountElement = document.createElement('p');
        newPAmountElement.textContent = `Amount: ${inputAmountElement.value}$`;
        const newPDateElement = document.createElement('p');
        newPDateElement.textContent = `Date: ${inputDateElement.value}`;

        newArticleElement.appendChild(newPTypeElement);
        newArticleElement.appendChild(newPAmountElement);
        newArticleElement.appendChild(newPDateElement);

        newLiElement.appendChild(newArticleElement);

        const newDivButtonsElement = document.createElement('div');
        newDivButtonsElement.classList.add('buttons');
        const newButtonEditElement = document.createElement('button');
        newButtonEditElement.classList.add('btn');
        newButtonEditElement.classList.add('edit');
        newButtonEditElement.textContent = 'edit';

        newButtonEditElement.addEventListener(('click'), () => {
            inputExpenseElement.value = newPTypeElement.textContent.replace('Type: ', '');
            inputAmountElement.value = newPAmountElement.textContent.replace('Amount: ', '').replace('$', '');
            inputDateElement.value = newPDateElement.textContent.replace('Date: ', '');
            newButtonEditElement.parentElement.parentElement.remove();
            addButtomElement.removeAttribute('disabled');
        });

        const newButtonOkElement = document.createElement('button');
        newButtonOkElement.classList.add('btn');
        newButtonOkElement.classList.add('ok');
        newButtonOkElement.textContent = 'ok';

        newButtonOkElement.addEventListener(('click'), () => {
            expensesListElement.appendChild(newButtonOkElement.parentElement.parentElement);
            newButtonOkElement.parentElement.remove();
            addButtomElement.removeAttribute('disabled');
        });

        newDivButtonsElement.appendChild(newButtonEditElement);
        newDivButtonsElement.appendChild(newButtonOkElement);
        newLiElement.appendChild(newDivButtonsElement)
        previewListElement.appendChild(newLiElement);

        inputExpenseElement.value = '';
        inputAmountElement.value = '';
        inputDateElement.value = '';

        addButtomElement.setAttribute('disabled', 'true');
    });

    
}