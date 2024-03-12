function formatGrade(grade) {
    let result = ``;
    if (grade < 3) {
        return `Fail (2)`
    } else if (grade < 3.50){
        result = `Poor`
    } else if (grade < 4.50){
        result = `Good`
    } else if (grade < 5.50){
        result = `Very good`
    } else if (grade >= 5.50){
        result = `Excellent`
    }
    
    return `${result} (${grade.toFixed(2)})`
}

console.log (formatGrade(3.33));
console.log (formatGrade(4.50));
console.log (formatGrade(2.99));