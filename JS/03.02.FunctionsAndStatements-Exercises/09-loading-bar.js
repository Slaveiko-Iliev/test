const isFinish = (num) => num === 100;

const printUnfinishedBar = (num) => console.log(`${num}% [${'%'.repeat(num / 10)}${'.'.repeat((100 - num) / 10)}]\nStill loading...`);
                                    // console.log(`Still loading...`);

const printfinishedBar = () => console.log(`100% Complete!\n[${'%'.repeat(10)}]`)
                                // console.log(`${'%'.repeat(10)}`);

function solve(number) {
    const isFinish = (num) => num === 100;

    const printUnfinishedBar = (num) => console.log(`${num}% [${'%'.repeat((100 - num) / 10)}${'.'.repeat((100 - num) / 10)}]\nStill loading...`);
    
    const printfinishedBar = () => console.log(`100% Complete!\n[${'%'.repeat(10)}]`)

    isFinish(number) ? printfinishedBar() : printUnfinishedBar(number);
}

solve (30);
// solve (50);
// solve (100);