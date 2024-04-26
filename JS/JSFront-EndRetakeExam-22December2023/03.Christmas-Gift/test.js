fetch(`${baseURL}/${giftId}`, {
    method: 'PUT',
    headers: {
        'content-type': 'application/json',
    },
    body: JSON.stringify({
        "gift": inputGiftElement.value,
        "for": inputForElement.value,
        "price": inputPriceElement.value,
        "_id": giftId,
    })
})

// addPresentElement.removeAttribute('disabled');
// editPresentElement.setAttribute('disabled', 'disabled');
// loadPresents();