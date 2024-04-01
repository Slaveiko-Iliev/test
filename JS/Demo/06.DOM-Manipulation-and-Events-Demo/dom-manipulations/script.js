// DOM Query
const movieListElement = document.getElementById('movies');
const firstMovieElement = document.querySelector('.first-movie');

// Create Elemetn
const secondMovieElement = document.createElement('li');
secondMovieElement.textContent = 'Man of Steel';

// Append new element to dom
movieListElement.appendChild(secondMovieElement);

// Append existing element to dom
setTimeout(() => {
    movieListElement.appendChild(firstMovieElement);
}, 2000);

// Clone existing element and prepend
const firstMovieCloneElement = firstMovieElement.cloneNode(true);
firstMovieCloneElement.textContent = 'Passion of Christ';
movieListElement.prepend(firstMovieCloneElement);

// Append element on specific place before another child element
const thirdMovieElement = document.createElement('li');
thirdMovieElement.textContent = 'Lord of the Rings';

movieListElement.insertBefore(thirdMovieElement, secondMovieElement);

// Use before or after 
const fourthMovieElement = document.createElement('li');
fourthMovieElement.textContent = 'The Case for Christ';
thirdMovieElement.after(fourthMovieElement); // or .before
