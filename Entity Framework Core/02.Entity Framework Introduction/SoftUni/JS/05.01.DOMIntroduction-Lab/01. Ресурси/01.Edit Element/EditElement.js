function editElement(element, stringMatch, replacer ) {
    while (element.textContent.includes(stringMatch)) {
        element.textContent = element.textContent.replace(stringMatch, replacer);
    }

}