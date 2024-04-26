function solve() {
    const baseURL = `http://localhost:3030/jsonstore/gifts`;

    const loadPresentsElement = document.getElementById('load-presents');
    const inputGiftElement = document.getElementById('gift');
    const inputForElement = document.getElementById('for');
    const inputPriceElement = document.getElementById('price');
    const giftListElement = document.getElementById('gift-list');
    const addPresentElement = document.getElementById('add-present');
    const editPresentElement = document.getElementById('edit-present');

    loadPresentsElement.addEventListener(('click'), loadPresents);

    addPresentElement.addEventListener(('click'), () => {
        fetch(baseURL, {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify({
                'gift': inputGiftElement.value,
                'for': inputForElement.value,
                'price': inputPriceElement.value,
            })
        })
            .then(res => res.json())
            .then(data => {
                loadPresents();
                inputGiftElement.value = '';
                inputForElement.value = '';
                inputPriceElement.value = '';
            })
            .catch(err => console.log(err));

        // loadPresents();
        // inputGiftElement.value = '';
        // inputForElement.value = '';
        // inputPriceElement.value = '';
    });

    editPresentElement.addEventListener(('click'), () => {
        
        const giftId = divGiftSockElement.getAttribute('data-id');
        fetch(`${baseURL}/${giftId}`, {
            method: 'PUT',
            headers: {
                'content-type': 'application/json',
            },
            body: JSON.stringify({
                "gift": inputGiftElement.value,
                "for": inputForElement.value,
                "price": inputPriceElement.value,
                "_id": giftId,
            })
        })

        addPresentElement.removeAttribute('disabled');
        editPresentElement.setAttribute('disabled', 'disabled');

        loadPresents();
        // fetch(`${url}/people/1`)
        // .then(response => response.json())
        // .then(data => {
            
        // })
        // .catch(error => console.log('Something went wrong'));
    });

    function loadPresents() {
        giftListElement.innerHTML = ``;

        fetch(`${baseURL}`)
            .then(response => response.json())
            .then(data => {
                const giftList = Object.values(data);
                
                for (const record of giftList) {
                    const divGiftSockElement = document.createElement('div');
                    divGiftSockElement.classList.add('gift-sock');
                    // console.log(record);
                    // divGiftSockElement.setAttribute(`data-id`, record._id);
                    // console.log(divContentElement.getAttribute(`data-id`));
            
                    const divContentElement = document.createElement('div');
                    divContentElement.classList.add('content');
            
                    const pPresentElement = document.createElement('p');
                    pPresentElement.textContent = record.gift;
                    const pForElement = document.createElement('p');
                    pForElement.textContent = record.for;
                    const pPriceElement = document.createElement('p');
                    pPriceElement.textContent = record.price;
            
                    divContentElement.appendChild(pPresentElement);
                    divContentElement.appendChild(pForElement);
                    divContentElement.appendChild(pPriceElement);
                    divGiftSockElement.appendChild(divContentElement);
            
                    const buttonsContainerElement = document.createElement('div');
                    buttonsContainerElement.classList.add('buttons-container');
                    const changeBtnElement = document.createElement('button');
                    changeBtnElement.classList.add('change-btn');
                    changeBtnElement.textContent = 'Change';

                    changeBtnElement.addEventListener(('click'), () => {
                        inputGiftElement.value = pPresentElement.textContent;
                        inputForElement.value = pForElement.textContent;
                        inputPriceElement.value = pPriceElement.textContent;
                        divGiftSockElement.remove();

                        editPresentElement.removeAttribute('disabled');
                        addPresentElement.setAttribute('disabled', 'disabled');
                    });

                    const deleteBtnElement = document.createElement('button');
                    deleteBtnElement.classList.add('delete-btn');
                    deleteBtnElement.textContent = 'Delete';
            
                    buttonsContainerElement.appendChild(changeBtnElement);
                    buttonsContainerElement.appendChild(deleteBtnElement);
                    divGiftSockElement.appendChild(buttonsContainerElement);
                    giftListElement.appendChild(divGiftSockElement);

                    addPresentElement.removeAttribute('disabled');
                    editPresentElement.setAttribute('disabled', 'disabled');
        
                    loadPresents();
                }
            })
            .catch(error => console.log('Something went wrong'));
        
            // editPresentElement.addEventListener(('click'), () => {
        
                // const giftId = divGiftSockElement.getAttribute('data-id');
                // fetch(`${baseURL}/${giftId}`, {
                //     method: 'PUT',
                //     headers: {
                //         'content-type': 'application/json',
                //     },
                //     body: JSON.stringify({
                //         "gift": inputGiftElement.value,
                //         "for": inputForElement.value,
                //         "price": inputPriceElement.value,
                //         "_id": giftId,
                //     })
                // })
        
                // addPresentElement.removeAttribute('disabled');
                // editPresentElement.setAttribute('disabled', 'disabled');
        
                // loadPresents();
                // fetch(`${url}/people/1`)
                // .then(response => response.json())
                // .then(data => {
                    
                // })
                // .catch(error => console.log('Something went wrong'));
            // });
    }
}

solve();