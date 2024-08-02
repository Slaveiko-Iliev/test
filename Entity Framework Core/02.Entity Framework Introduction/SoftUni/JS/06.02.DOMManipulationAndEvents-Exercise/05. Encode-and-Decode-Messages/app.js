function encodeAndDecodeMessages() {
    const senderTextarea = document.querySelector('#main textarea:nth-of-type(1)');
    const receiverTextarea = document.querySelector('#main div:nth-child(2) textarea');
    const encodeButtonElement = document.querySelector('#main div:nth-child(1) button');
    const decodeButtonElement = document.querySelector('#main div:nth-child(2) button');
    
    encodeButtonElement.addEventListener('click', () => {
        const inputMessage = senderTextarea.value;
        let encodedMesage = '';
        
        for (let i = 0; i < inputMessage.length; i++) {
            const encodedChar = inputMessage.charCodeAt(i);
            
            encodedMesage += String.fromCharCode(encodedChar + 1);
        }

        receiverTextarea.value = encodedMesage;
        senderTextarea.value = '';
    });

    decodeButtonElement.addEventListener('click', () => {
        const encodedMessage = receiverTextarea.value;
        let decodedMesage = '';

        for (let i = 0; i < encodedMessage.length; i++) {
            const decodedChar = encodedMessage.charCodeAt(i);
            
            decodedMesage += String.fromCharCode(decodedChar - 1);
        }

        receiverTextarea.value = decodedMesage;
    });
}