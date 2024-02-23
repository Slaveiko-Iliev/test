function solve(text) {
    let pattern = /[a-zA-Z0-9]+/g;
    let result = text.match(pattern);

    for (let i = 0; i < result.length; i++) {
        result[i] = result[i].toUpperCase();
    }

    console.log(result.join(', '));
}

solve('Hi, how a3re you?');
solve('hello');

// console.log(result);
        // result.forEach(element => {
        //     element.toUpperCase();
        // });
        // console.log(result.toUpperCase.join('-'));