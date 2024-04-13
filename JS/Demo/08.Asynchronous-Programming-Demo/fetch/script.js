const url = 'https://swapi.dev/api';

// Promise chaining
fetch(`${url}/people/1`)
    .then(response => response.json())
    .then(data => console.log(data))
    .catch(error => console.log('Something went wrong'));


// Using server to get books
// const booksUrl = 'http://localhost:3030/jsonstore/books';
// fetch(booksUrl)
//     .then(res => res.json())
//     .then(data => console.log(data))
    // .catch(error => console.log(error))

// create book
fetch(booksUrl, {
    method: 'POST',
    headers: {
        'content-type': 'application/json'
    },
    body: JSON.stringify({
        title: 'Chronicles of Narnia',
        author: 'C.S.Lewis',
    })
})
    .then(res => res.json())
    .then(data => console.log(data))
    .catch(err => console.log(err));

// Edit book
// The Lion, the Witch and the Wardrobe
// fetch(`${booksUrl}/2d962e2b-d44d-4955-9382-154aee108d02`, {
//     method: 'PUT',
//     headers: {
//         'content-type': 'application/json',
//     },
//     body: JSON.stringify({
//         "title": "Chronicles of Narnia: The Lion, the Witch and the Wardrobe",
//         "author": "C.S.Lewis",
//         "_id": "2d962e2b-d44d-4955-9382-154aee108d02"
//     })
// })

// DElete book
// fetch(`${booksUrl}/3e6669e7-e0b4-401a-aa38-cefd20346480`, {
//     method: 'DELETE'
// })
//     .fetch(res => console.log(res))
//     .catch(err => console.log(err));
