function solve() {
    const baseURL = `http://localhost:3030/jsonstore/gifts`;

    const loadPresentsElement = document.getElementById('load-presents');
    const inputGiftElement = document.getElementById('gift');
    const inputForElement = document.getElementById('for');
    const inputPriceElement = document.getElementById('price');
    const giftListElement = document.getElementById('gift-list');

    loadPresentsElement.addEventListener(('click'), () => {
        giftListElement.innerHTML = ``;

        fetch(`${baseURL}`)
            .then(response => response.json())
            .then(data => {
                const giftList = Object.values(data);
                
                for (const record of giftList) {
                    const divGiftSockElement = document.createElement('div');
                    divGiftSockElement.classList.add('gift-sock');
            
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
                    const deleteBtnElement = document.createElement('button');
                    deleteBtnElement.classList.add('delete-btn');
                    deleteBtnElement.textContent = 'Delete';
            
                    buttonsContainerElement.appendChild(changeBtnElement);
                    buttonsContainerElement.appendChild(deleteBtnElement);
                    divGiftSockElement.appendChild(buttonsContainerElement);
                    giftListElement.appendChild(divGiftSockElement);
                }
            })
            .catch(error => console.log('Something went wrong'));

    });

}

solve();