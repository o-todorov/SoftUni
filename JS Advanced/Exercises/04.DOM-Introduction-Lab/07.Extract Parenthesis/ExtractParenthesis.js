function extract(content) {
    const regex = /\([^\)]*\)/g;

    return document.getElementById(content)
                    .textContent
                    .match(regex)
                    .map(x => x.slice(1, -1))
                    .join('; ');
}
