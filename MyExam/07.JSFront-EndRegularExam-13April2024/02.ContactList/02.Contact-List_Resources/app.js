window.addEventListener("load", solve);

function solve() {
    const addbuttonElement = document.getElementById('add-btn');
    const nameElement = document.getElementById('name');
    const phoneElement = document.getElementById('phone');
    const categoryElement = document.getElementById('category');

    const checklistElement = document.getElementById('check-list');

    addbuttonElement.addEventListener('click', addContact);

    function addContact () {
      if (nameElement.value !== `` && phoneElement.value !== `` & categoryElement.value !== ``){
        const newLi = document.createElement('li');
        const newArticle = document.createElement('article');
      
        const currentName = document.createElement('p');
        currentName.textContent = `name:${nameElement.value}`;
        newArticle.appendChild(currentName);
  
        const currentPhone = document.createElement('p');
        currentPhone.textContent = `phone:${phoneElement.value}`;
        newArticle.appendChild(currentPhone);
  
        const currentCategory = document.createElement('p');
        currentCategory.textContent = `category:${categoryElement.value}`;
        newArticle.appendChild(currentCategory);
  
        const currentDiv = document.createElement('div');
        currentDiv.classList.add('buttons');
  
        const editButtonElement = document.createElement('button');
        editButtonElement.classList.add('edit-btn');
        
        editButtonElement.addEventListener('click', () => {
          nameElement.value = currentName.textContent.substring(5);
          phoneElement.value = Number(currentPhone.textContent.substring(6));
          categoryElement.value = currentCategory.textContent.substring(9);
  
          editButtonElement.parentElement.parentElement.remove();
          
        });
  
        const saveButtonElement = document.createElement('button');
        saveButtonElement.classList.add('save-btn');
        
        saveButtonElement.addEventListener('click', () => {
          currentLiElement = saveButtonElement.parentElement.parentElement;
          saveButtonElement.parentElement.remove();
          const delButtonElement = document.createElement('button');
          delButtonElement.classList.add('del-btn');

          delButtonElement.addEventListener('click', () => {
            delButtonElement.parentElement.remove();
          });

          currentLiElement.appendChild(delButtonElement);


          const contactListElement = document.getElementById('contact-list');
          contactListElement.appendChild(currentLiElement);
        });
  
        currentDiv.appendChild(editButtonElement);
        currentDiv.appendChild(saveButtonElement);
  
        newLi.appendChild(newArticle);
        newLi.appendChild(currentDiv);
        checklistElement.appendChild(newLi);
  
        nameElement.value = ``;
        phoneElement.value = ``;
        categoryElement.value = ``;
      }
  
      }
  }
  