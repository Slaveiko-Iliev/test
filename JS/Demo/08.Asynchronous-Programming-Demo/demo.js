// Async programming with callback
console.log('start');

delayStart(() => {
    console.log('delayed start1')
}, 2000);

delayStart(() => {
    console.log('delayed start2')
}, 1000);

console.log('finish');

function delayStart(callback, time = 2000) {
    setTimeout(() => {
        callback();   
    }, time);
}
