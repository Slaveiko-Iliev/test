const weddingPromise = new Promise((resolve, reject) => {
    if (Math.random() < 0.3) {
        return reject('Sorry, It\'s me!');
    }

    setTimeout(() => {
        resolve('Just Married!'); 
    }, 5000);
});

weddingPromise
    .then((message) => {
        console.log(message);
    })
    .catch(message => {
        console.log(message);
    })
    .finally(() => {
        console.log('Love always wins!');
    });

// Always rejecting promise
const rejectingPromise = Promise.reject('Sorry next time');
console.log(rejectingPromise);
rejectingPromise.catch((message) => console.log(message));


// Multiple parallel promises
const createTimeoutPromise = function(message, time) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve(message);
        }, time);
    });
}

// Try Promise.allSettled
const groupPromise = Promise.all([
    Promise.resolve('First promise'),
    createTimeoutPromise('second promise', 3000),
    createTimeoutPromise('third promise', 1000),
    // Promise.reject('sorrty'),
]);

groupPromise
    .then((values) => {
        console.log(values);
    })
    .catch(error =>  {
        console.log(error);
    });
