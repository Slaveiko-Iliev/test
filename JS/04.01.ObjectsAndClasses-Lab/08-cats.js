function solve(input) {
    class Cat {
        constructor(name, age){
            this.name = name;
            this.age = age;
        }
        meow (){
            console.log(`${this.name}, age ${this.age} says Meow` );
        }
    }

    for (const cat of input) {
        const catInfo = cat.split(' ');
        const name = catInfo[0];
        const age = catInfo[1];
        const currentCat = new Cat (name, age);
        currentCat.meow();
    }
}

solve(['Mellow 2', 'Tom 5']);
solve(['Candy 1', 'Poppy 3', 'Nyx 2']);