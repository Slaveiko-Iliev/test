function solve (template, text) {
    let templateToLower = template.toLowerCase();
    let textAsArray = text
        .toLowerCase()
        .split(' ');
    if (textAsArray.includes(templateToLower)){
        console.log (templateToLower);
    } else {
        console.log (`${templateToLower} not found!`);
    }
}

solve ('javascript',
'JavaScript is the best programming language'
);
solve ('python',
'JavaScript is the best programming language'
);