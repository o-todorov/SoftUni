
function getAllFurniture(url){
    let furniture = {};
    (async () => {
        let req =  await fetch(url);
        furniture = await(req => req.json());
    })();

    return furniture;
}

export {getAllFurniture};