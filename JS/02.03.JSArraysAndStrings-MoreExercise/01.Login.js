function solve (passList){
    let username = passList[0];
    let pass;
    tryCount = 0;
    
    for (let i = 1; i < passList.length; i++) {
        let currentPass = passList[i];
        pass = ``;
        for (let j = currentPass.length - 1; j >= 0; j--) {
            pass += currentPass[j];
        }
        if (username === pass){
            return console.log (`User ${username} logged in.`);
        } else if (username !== pass && tryCount === 3) {
            return console.log (`User ${username} blocked!`);
        } else {
            console.log (`Incorrect password. Try again.`);
            tryCount ++;
        }
    }

    
}

solve (['Acer','login','go','let me in','recA']);
solve (['momo','omom']);
solve (['sunny','rainy','cloudy','sunny','not sunny']);