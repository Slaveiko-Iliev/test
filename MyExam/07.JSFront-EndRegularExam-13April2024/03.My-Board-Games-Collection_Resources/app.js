const baseUrl = `http://localhost:3030/jsonstore/games`;
const gamesListElement = document.getElementById('games-list');
const loadButtonElement = document.getElementById('load-games');
const editGameButtonElement = document.getElementById('edit-game');
const addGameButtonElement = document.getElementById('add-game');
const gameNameInputElement = document.getElementById('g-name');
const gameTypeInputElement = document.getElementById('type');
const gamePlayersInputElement = document.getElementById('players');

loadButtonElement.addEventListener('click', loadGames);
addGameButtonElement.addEventListener('click', addGames);

function loadGames() {
    fetch(baseUrl)
.then(response => response.json())
.then(dataGame => {
    gamesListElement.innerHTML = ``;
    const allGameList = Object.values(dataGame);

    for (const game of allGameList) {
        const divBoardGame = document.createElement('div');
        divBoardGame.classList.add('board-game');

        const divContent = document.createElement('div');
        divContent.classList.add('content');

        const pName = document.createElement('p');
        pName.textContent = game.name;

        const pCount = document.createElement('p');
        pCount.textContent = game.players;

        const pType = document.createElement('p');
        pType.textContent = game.type;

        divContent.appendChild(pName);
        divContent.appendChild(pCount);
        divContent.appendChild(pType);
        divBoardGame.appendChild(divContent);

        const divButtonsContainer = document.createElement('div');
        divButtonsContainer.classList.add('buttons-container');

        const changeButton = document.createElement('button');
        changeButton.textContent = 'Change';
        changeButton.classList.add('change-btn');

        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.classList.add('change-btn');

        divButtonsContainer.appendChild(changeButton);
        divButtonsContainer.appendChild(deleteButton);

        divBoardGame.appendChild(divButtonsContainer);
        gamesListElement.appendChild(divBoardGame);

        editGameButtonElement.setAttribute("disabled","true");
    }
})
.catch(error => console.log('Something went wrong'));
}

function addGames() {
    const newGame = {
        "name": gameNameInputElement.value,
        "type": gameTypeInputElement.value,
        "players": gamePlayersInputElement.value,
        "_id": '',
    }

    fetch(baseUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({newGame})
    })
        .then(res => res.json())
        .then(data => console.log(data))
        .catch(err => console.log(err));
    
        loadGames();
        gameNameInputElement.value = ``;
        gameTypeInputElement.value = ``;
        gamePlayersInputElement.value = ``;
}
