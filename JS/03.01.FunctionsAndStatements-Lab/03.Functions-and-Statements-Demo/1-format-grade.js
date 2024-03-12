function classicFormatGrade(grade) {
    let formatedGrade = '';

    if (grade < 3) {
        formatedGrade = `Fail (${grade})`;
    } else if (grade < 3.5) {
        formatedGrade = `Poor (${grade.toFixed(2)})`;
    } else if (grade < 4.5) {
        formatedGrade = `Good (${grade.toFixed(2)})`;
    } else if (grade < 5.5) {
        formatedGrade = `Very good (${grade.toFixed(2)})`;
    } else {
        formatedGrade = `Excellent (${grade.toFixed(2)})`;
    }

    return formatedGrade;
}

function solve(grade) {
    const result = formatGrade(grade);

    console.log(result);

    function formatGrade(grade) {
        if (grade < 3) {
            return `Fail (${grade})`;
        }

        if (grade < 3.5) {
            return `Poor (${grade.toFixed(2)})`;
        }

        if (grade < 4.5) {
            return `Good (${grade.toFixed(2)})`;
        }

        if (grade < 5.5) {
            return `Very good (${grade.toFixed(2)})`;
        }

        return `Excellent (${grade.toFixed(2)})`;
    }
}

solve(3.33);
