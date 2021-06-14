function extract(content) {
    const regex = /(?<=\()[^\(\)]*(?=\))/g;
    return  document.getElementById(content)
                    .textContent
                    .match(regex)
                    .join('; ');
}
