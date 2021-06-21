function encodeAndDecodeMessages() {
    let senderElement = document.querySelectorAll('#main textarea')[0];
    let buttonEncode = senderElement.nextElementSibling;
    buttonEncode.addEventListener('click', encodeMessage);
    let decodeElement = document.querySelectorAll('#main textarea')[1];
    let buttonDecode = decodeElement.nextElementSibling;
    buttonDecode.addEventListener('click', decodeMessage);

    function encodeMessage(){
        decodeElement.value = [...senderElement.value]
                        .map(ch => String.fromCharCode(ch.charCodeAt() + 1))
                        .join('');
        senderElement.value = '';
    }

    function decodeMessage(){
        decodeElement.value = [...decodeElement.value]
                    .map(ch => String.fromCharCode(ch.charCodeAt() - 1))
                    .join('');
    }
}