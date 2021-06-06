function HeroesOfCodeAndLogicVII(lines){
    class Hero{
        constructor(name, HP, MP){
            this.Name = name;
            this.HP = HP;
            this.MP = MP;
        }
        SpellSuccessful(mana){
            if(mana <= this.MP){
                this.MP -= mana;
                return true;
            }
            return false;
        }
        TakeDamage(damage) {
            let hpTaken = Math.min(this.HP, damage)
            this.HP -= hpTaken;
            return hpTaken;
        }
        get IsAlive(){
            return this.HP > 0;
        }
        Recharge(amount){
            let added = Math.min(200 - this.MP, amount);
            this.MP += added;
            return added;
        }
        Heal(amount){
            let added = Math.min(100 - this.HP, amount);
            this.HP += added;
            return added;
        }
    }
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
            heroes[hero] = new Hero(hero, Number(hp), Number(mp));      
        });
    }
    function ExecuteCommands(lines){
        lines.forEach(line => {
            [command, heroName,...args] = line.split(' - ');
            let retVal = commands[command](heroes[heroName], args);
            console.log(retVal);      
        });
    }
    function CastSpell(hero, [manaNeeded, spellName]){
        if(hero.SpellSuccessful(Number(manaNeeded))){
            return `${hero.Name} has successfully cast ${spellName} and now has ${hero.MP} MP!`;
        }
        return `${hero.Name} does not have enough MP to cast ${spellName}!`;
    }
    function TakeDamage(hero, [damage, attacker]){
        damageTaken = hero.TakeDamage(Number(damage));
        if(hero.IsAlive){
            return `${hero.Name} was hit for ${damageTaken} HP by ${attacker} and now has ${hero.HP} HP left!`;
        }
        
        delete heroes[hero.Name];
        return (`${hero.Name} has been killed by ${attacker}!`);
    }
    function Recharge(hero, [amountToRecharge]){
        used = hero.Recharge(Number(amountToRecharge));
        return `${hero.Name} recharged for ${used} MP!`;
    }
    function Heal(hero, [amountToHeal]){
        used = hero.Heal(Number(amountToHeal));
        return `${hero.Name} healed for ${used} HP!`;
    }
    function PrintSurvivers(){
        let sorted = Object.values(heroes)
                            .sort(SortHeroes);
        sorted.forEach(hero => {
            console.log(`${hero.Name}\n  HP: ${hero.HP}\n  MP: ${hero.MP}`);
        })

        function SortHeroes(aHero, bHero){
            let result = bHero.HP - aHero.HP;
            return result == 0 ? aHero.Name.localeCompare(bHero.Name) : result;
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