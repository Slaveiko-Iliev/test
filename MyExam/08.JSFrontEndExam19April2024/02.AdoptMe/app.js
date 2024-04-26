window.addEventListener("load", solve);

function solve() {
    const  ulAdoptionInfoElement = document.getElementById('adoption-info');
    const  ulAdoptedListElement = document.getElementById('adopted-list');
    const  inputTypeElement = document.getElementById('type');
    const  inputAgeElement = document.getElementById('age');
    const  inputGenderElement = document.getElementById('gender');
    const  buttonAdoptElement = document.getElementById('adopt-btn');

  buttonAdoptElement.addEventListener(('click'),(е) => {
      е.preventDefault();
      if (inputTypeElement.value !== '' && inputAgeElement.value !== '' && inputGenderElement.value !== '') {
        const liNewElement = document.createElement('li');
    
        const articleElement = document.createElement('article');
    
        const pPetElement = document.createElement('p');
        pPetElement.textContent = `Pet:${inputTypeElement.value}`;
        const pGenderElement = document.createElement('p');
        pGenderElement.textContent = `Gender:${inputGenderElement.value}`;
        const pAgeElement = document.createElement('p');
        pAgeElement.textContent = `Age:${inputAgeElement.value}`;
    
        articleElement.appendChild(pPetElement);
        articleElement.appendChild(pGenderElement);
        articleElement.appendChild(pAgeElement);
        liNewElement.appendChild(articleElement);
    
        const divButtonsElement = document.createElement('div');
        divButtonsElement.classList.add('buttons');
    
        const buttonEditElement = document.createElement('button');
        buttonEditElement.classList.add('edit-btn');
        buttonEditElement.textContent = 'Edit';

        buttonEditElement.addEventListener(('click'), () => {
          inputTypeElement.value = pPetElement.textContent.replace('Pet:','');
          inputGenderElement.value = pGenderElement.textContent.replace('Gender:','');
          inputAgeElement.value = pAgeElement.textContent.replace('Age:','');

          buttonEditElement.parentElement.parentElement.remove();
        });

        const buttonDoneElement = document.createElement('button');
        buttonDoneElement.classList.add('done-btn');
        buttonDoneElement.textContent = 'Done';

        buttonDoneElement.addEventListener(('click'), () => {
          const doneParentParent = buttonDoneElement.parentElement.parentElement;

          buttonDoneElement.parentElement.remove();

          const buttonClearElement = document.createElement('button');
          buttonClearElement.classList.add('clear-btn');
          buttonClearElement.textContent = 'Clear';

          buttonClearElement.addEventListener(('click'), () => {
            buttonClearElement.parentElement.remove();
          });

          doneParentParent.appendChild(buttonClearElement);

          ulAdoptedListElement.appendChild(doneParentParent);
        });
    
        divButtonsElement.appendChild(buttonEditElement);
        divButtonsElement.appendChild(buttonDoneElement);
        liNewElement.appendChild(divButtonsElement);
    
        ulAdoptionInfoElement.appendChild(liNewElement);
    
        inputTypeElement.value = '';
        inputGenderElement.value = '';
        inputAgeElement.value = '';
      }
    });
  }
  
