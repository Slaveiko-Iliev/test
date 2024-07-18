function solve(input) {
    class Song {
        constructor (typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    const songList = [];
    const N = input[0];

    for (let i = 1; i <= N; i++) {
        const songInfo = input[i].split('_');
        const typeList = songInfo[0];
        const name = songInfo[1];
        const time = songInfo[2];
        const song = new Song(typeList, name, time);
        songList.push(song);
    }

    const type = input[N+1];

    if (type === `all`){
        songList.forEach(song => console.log(song.name));
    } else {
        songList.filter(song => song.typeList === type).forEach(song => console.log(song.name));
    }
}

solve([3,
    'favourite_DownTown_3:14',
    'favourite_Kiss_4:16',
    'favourite_Smooth Criminal_4:01',
    'favourite']
    );
solve([4,
    'favourite_DownTown_3:14',
    'listenLater_Andalouse_3:24',
    'favourite_In To The Night_3:58',
    'favourite_Live It Up_3:48',
    'listenLater']
    
    );
solve([2,
    'like_Replay_3:15',
    'ban_Photoshop_3:48',
    'all']
    
    );