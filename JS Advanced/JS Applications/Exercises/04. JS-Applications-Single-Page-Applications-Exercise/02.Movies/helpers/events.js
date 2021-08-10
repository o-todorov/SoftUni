export let stateChange = function (state){
    let event = new CustomEvent("stateChange", { detail: { state } });
    document.body.dispatchEvent(event);
}
export let viewChange = function (view, movieId){
    let event = new CustomEvent("viewChange", { detail: { view, movieId } });
    document.body.dispatchEvent(event);
}