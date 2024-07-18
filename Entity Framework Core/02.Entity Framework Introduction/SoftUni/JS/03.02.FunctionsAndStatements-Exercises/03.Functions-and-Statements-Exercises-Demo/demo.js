const matches = 'aabaa'.matchAll(/a/g);

const arrayMatches = Array.from(matches);
console.log(Array.isArray(arrayMatches));

