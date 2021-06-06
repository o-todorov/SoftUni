function HeroesOfCodeAndLogicVII(lines){
    const maxManaPoints = 200;
    const maxHitPoints = 100;
    let heroes = {};
    let count = Number(lines[0]);
    let commands = {
        'CastSpell':CastSpell,
        'TakeDamage':TakeDamage,
        'Recharge':Recharge,
        'Heal':Heal
    }
    ReadHeroes(lines.slice(1, count + 1));
    ExecuteCommands(lines.slice(count + 1, lines.indexOf('End')));
    PrintSurvivers();

    function ReadHeroes(lines){
        lines.forEach(line => {
            [hero, hp, mp] = line.split(' ');
            heroes[hero] = {hits:Number(hp), mana:Number(mp)};      
        });
    }
    function ExecuteCommands(lines){
        lines.forEach(line => {
            [command, hero,...args] = line.split(' - ');
            let retVal = commands[command](hero, heroes[hero], args);
            console.log(retVal);      
        });
    }
    function CastSpell(heroName, hero, [manaNeeded, spellName]){
        manaNeeded = Number(manaNeeded);
        if(hero.mana >= manaNeeded){
            hero.mana -= manaNeeded;
            return `${heroName} has successfully cast ${spellName} and now has ${hero.mana} MP!`;
        }
        return `${heroName} does not have enough MP to cast ${spellName}!`;
    }
    function TakeDamage(heroName, hero, [damage, attacker]){
        damage = Math.min(hero.hits, Number(damage));
        hero.hits -= damage;
        if(hero.hits > 0){
            return `${heroName} was hit for ${damage} HP by ${attacker} and now has ${hero.hits} HP left!`;
        }
        
        delete heroes[heroName];
        return (`${heroName} has been killed by ${attacker}!`);
    }
    function Recharge(heroName, hero, [amountToRecharge]){
        amountToRecharge = Math.min(maxManaPoints - hero.mana, Number(amountToRecharge));
        hero.mana += amountToRecharge;
        return `${heroName} recharged for ${amountToRecharge} MP!`;
    }
    function Heal(heroName, hero, [amountToHeal]){
        amountToHeal = Math.min(maxHitPoints - hero.hits, Number(amountToHeal));
        hero.hits += amountToHeal;
        return `${heroName} healed for ${amountToHeal} HP!`;
    }
    function PrintSurvivers(){
        let sorted = Object.entries(heroes)
                            .sort(SortHeroes);
        sorted.forEach( ([heroName, hero]) => {
            console.log(`${heroName}\n  HP: ${hero.hits}\n  MP: ${hero.mana}`);
        })

        function SortHeroes([aName,aHero], [bName,bHero]){
            let result = bHero.hits - aHero.hits;
            return result == 0 ? aName.localeCompare(bName) : result;
        }
    }
}

HeroesOfCodeAndLogicVII([
    '2',
    'Solmyr 85 120',
    'Kyrre 99 50',
    'Heal - Solmyr - 10',
    'Recharge - Solmyr - 50',
    'TakeDamage - Kyrre - 66 - Orc',
    'CastSpell - Kyrre - 15 - ViewEarth',
    'End'
    ])

HeroesOfCodeAndLogicVII([
'4',
'Adela 90 150',
'SirMullich 70 40',
'Ivor 1 111',
'Tyris 94 61',
'Heal - SirMullich - 50',
'Recharge - Adela - 100',
'CastSpell - Tyris - 1000 - Fireball',
'TakeDamage - Tyris - 94 - Fireball',
'TakeDamage - Ivor - 3 - Mosquito',
'End'
])