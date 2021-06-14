function editElement(elem, txtToReplace, newText) {
    let arr = elem.textContent.split(txtToReplace);
    elem.textContent = arr.join(newText);
}