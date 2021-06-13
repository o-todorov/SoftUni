function createSortedList(){
    let obj = {
        list: [],
        get size() {return  this.list.length}
    }
    obj.add = (x) => {
        obj.list.push(x);
        obj.list.sort((a, b) => a - b);
        },
    obj.get = (i) => {
            if(i < 0 || i >= obj.list.length) return;
            return obj.list[i];
        },
    obj.remove = (i) => {
            if(i < 0 || i >= obj.list.length) return;
            obj.list.splice(i, 1);
        }
    return obj;
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));