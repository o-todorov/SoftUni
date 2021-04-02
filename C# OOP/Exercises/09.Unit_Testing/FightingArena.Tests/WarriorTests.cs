using NUnit.Framework;

namespace Tests
{
    using FightingArena;
    public class WarriorTests
    {
        private const string    name    = "Warrior";
        private const int       damage  = 80;
        private const int       hp      = 100;
        private const int MIN_ATTACK_HP = 30;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(null      , damage    , hp)]
        [TestCase(""        , damage    , hp)]
        [TestCase(" "       , damage    , hp)]
        [TestCase("Warrior" , 0         , hp)]
        [TestCase("Warrior" , -5        , hp)]
        [TestCase("Warrior" , damage    , -5)]
        public void Ctor_ThrowsException_WhenInvalidArgument(string name, int damage, int hp)
        {
            Warrior warrior;

            Assert.That(() => warrior = new Warrior(name, damage, hp), Throws.ArgumentException);
        }

        [Test]
        public void Ctor_InitializeProprtiesCorrectly()
        {
            Warrior warrior = new Warrior(name, damage, hp);

            Assert.That(warrior.Name    , Is.EqualTo(name)      );
            Assert.That(warrior.Damage  , Is.EqualTo(damage)    );
            Assert.That(warrior.HP      , Is.EqualTo(hp)        );
        }

        [Test]
        [TestCase(MIN_ATTACK_HP         , hp                )]
        [TestCase(MIN_ATTACK_HP - 1     , hp                )]
        [TestCase(hp                    , MIN_ATTACK_HP     )]
        [TestCase(hp                    , MIN_ATTACK_HP - 1 )]
        [TestCase(damage - 1            , hp                )]
        public void Attack_ThrowException_WhenInvalidArgs(int attackerHP, int enemyHP)
        {
            var attacker    = new Warrior("W1", damage, attackerHP  );
            var enemy       = new Warrior("W2", damage, enemyHP     );
            Assert.That(() => attacker.Attack(enemy), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(damage    , damage - 1    )]
        [TestCase(damage    , damage        )]
        [TestCase(damage    , damage + 1    )]
        public void Attack_ShouldUpdateWarriorsHPsCorrectly(int attackerHP, int enemyHP)
        {
            var attacker            = new Warrior("W1", damage, attackerHP);
            var enemy               = new Warrior("W2", damage, enemyHP);
            int expectedAttackerHP  = attacker.HP - enemy.Damage;
            int expectedEnemyHP;

            if (attacker.Damage > enemy.HP)
            {
                expectedEnemyHP = 0;
            }
            else
            {
                expectedEnemyHP = enemy.HP - attacker.Damage;
            }

            attacker.Attack(enemy);

            Assert.That(attacker.HP     , Is.EqualTo(expectedAttackerHP));
            Assert.That(enemy.HP        , Is.EqualTo(expectedEnemyHP));
        }
    }
}