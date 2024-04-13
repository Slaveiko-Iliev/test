function attachEvents() {
    const baseURL = `http://localhost:3030/jsonstore/phonebook`;
    const btnLoadElement = document.getElementById('btnLoad');
    const phonebookElement = document.getElementById('phonebook');
    const btnCreateElement = document.getElementById('btnCreate');
    const inputPersonElement = document.getElementById('person');
    const inputPhoneElement = document.getElementById('phone');

    btnLoadElement.addEventListener('click', loadPhoneEntries);
    btnCreateElement.addEventListener('click', createPhoneEntries);

    
    async function loadPhoneEntries () {
        const responce = await fetch(baseURL);
        const phonebookEntriesValues = Object.values(await responce.json());

        phonebookElement.innerHTML = ``;

        for (const phoneEntry of phonebookEntriesValues) {
            const newLiEelement = document.createElement('li');
            newLiEelement.textContent = `${phoneEntry.person}: ${phoneEntry.phone}`;
            const newDeleteButton = document.createElement('button');
            newDeleteButton.textContent = `Delete`;
            
            newDeleteButton.addEventListener('click', () => {
                newDeleteButton.parentElement.remove();
                console.log(`${baseURL}/:${phoneEntry._id}`);
                fetch(`${baseURL}/${phoneEntry._id}`, {
                    method: 'DELETE'
                })
            });
            
            newLiEelement.appendChild(newDeleteButton);
            phonebookElement.appendChild(newLiEelement);
        }
    }

    async function createPhoneEntries() {
        const newPhoneEntry = {
            "person": `${inputPersonElement.value}`,
            "phone": `${inputPhoneElement.value}`,
          }
          
        fetch(baseURL, {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(newPhoneEntry)
        })
        .then(res => res.json())
        .then(data => console.log(data))
        .catch(err => console.log(err));

        inputPersonElement.value = ``;
        inputPhoneElement.value = ``;
        
        loadPhoneEntries ();
    }
}

attachEvents();