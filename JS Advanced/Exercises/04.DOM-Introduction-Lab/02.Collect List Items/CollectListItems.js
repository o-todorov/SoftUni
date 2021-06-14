function extractText() {
    let list = document.getElementById("items");
    let txt = document.getElementById("result");
    for (const item of Array.from(list.children)) {
        txt.textContent += item.textContent + '\n';
    }
}