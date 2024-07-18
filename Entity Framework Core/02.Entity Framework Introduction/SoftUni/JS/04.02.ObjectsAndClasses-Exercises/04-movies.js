function solve(input) {
    let movies =  [];

    for (const record of input) {
        const recordInfo = record.split(' ');

        if (recordInfo[0] === `addMovie`){
            recordInfo.shift();
            const currentMovieName = recordInfo.join(' ');
            if (!movies.find(movie => movie.name === currentMovieName)){
                let currentMovie = {
                    name: currentMovieName,
                }
                movies.push(currentMovie);
            }
        } else if (recordInfo.includes('directedBy')) {
            let index = recordInfo.findIndex(x => x == `directedBy`);
            let currentMovieName = recordInfo.slice(0, index).join(' ');
            let directorName = recordInfo.slice(index + 1).join(' ');
            let currentMovie = movies.find(movie => movie.name === currentMovieName);
            if (currentMovie){
                currentMovie.director = directorName;
            }
        } else if (recordInfo.includes(`onDate`)) {
            let index = recordInfo.findIndex(x => x == `onDate`);
            let currentMovieName = recordInfo.slice(0, index).join(' ');
            let onDate = recordInfo.slice(index + 1).join(' ');
            let currentMovie = movies.find(movie => movie.name === currentMovieName);
            if (currentMovie){
                currentMovie.date = onDate;
            }
        }
    }
    
    for (const movie of movies) {
        if (movie.date !== undefined && movie.director !== undefined){
            console.log(JSON.stringify(movie));
        }
        
    }
}

solve([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
    ]
    );

// solve([
//     'addMovie The Avengers',
//     'addMovie Superman',
//     'The Avengers directedBy Anthony Russo',
//     'The Avengers onDate 30.07.2010',
//     'Captain America onDate 30.07.2010',
//     'Captain America directedBy Joe Russo'
//     ]
    
//     );