const movieListElement = document.getElementById('movies');
const liveElementsCollection = movieListElement.children;
const liveNodeList = movieListElement.childNodes;
const staticNodeList = document.querySelectorAll('#movies li');

console.log(liveElementsCollection);
console.log(liveNodeList);
console.log(staticNodeList);
console.log('----------');

setTimeout(() => {
    const movieLiElement = document.createElement('li');
    movieLiElement.textContent = 'Case for Christ';
    movieListElement.appendChild(movieLiElement);

    console.log(liveElementsCollection);
    console.log(liveNodeList);
    console.log(staticNodeList);
}, 3000);
