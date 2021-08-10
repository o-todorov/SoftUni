function sortArr(arraytosort, ascending){
    let order = ascending == 'asc';
     let sort = {
         true: (arr) => {arr.sort((a, b) => a - b); return arr},
         false: (arr) => {arr.sort((a, b) => b - a); return arr}
     }

     return sort[order](arraytosort);
}


sortArr(
    [14, 7, 17, 6, 8], 'asc')

sortArr(
    [14, 7, 17, 6, 8], 'desc'
)