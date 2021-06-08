function HeroesInventory(arr){
    return JSON.stringify(arr.map(MakeHero));

    function MakeHero(line){
        let[name, level, items] = line.split(' / ');
        return( {
                name,
                level: Number(level),
                items: items?items.split(', '):[]
            }
        )
    }
}


console.log(
HeroesInventory(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / ']));
console.log(
HeroesInventory(['Jake / 1000 / Gauss, HolidayGrenade']));