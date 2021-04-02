using NUnit.Framework;

namespace Tests
{
    using FightingArena;

    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Ctor_CorrectlyInitializedListWarriors()
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Ctor_CreatesEmptyListOfWarriors()
        {
            Assert.That(arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void ArenaCount_ReturnsCorrectResultWhenEnroll()
        {
            string warriorName = "Warrior";
            arena.Enroll(new Warrior(warriorName, 80, 80));

            Assert.That(arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void Enroll_CorrectlyEnrollWarrior()
        {
            string warriorName = "Warrior";
            Warrior warrior = new Warrior(warriorName, 80, 80);
            arena.Enroll(warrior);
            CollectionAssert.Contains(arena.Warriors, (warrior));
        }

        [Test]
        public void Enroll_ThrowsException_WhenEnrolledAlreadyExist()
        {
            Warrior warrior = new Warrior("Warrioa", 80, 80);
            arena.Enroll(warrior);

            Assert.That(() => arena.Enroll(warrior), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase("Warrior"         , "WarriorNotIn"    )]
        [TestCase("WarriorNotIn"    , "Warrior"         )]
        [TestCase("WarriorNotIn"    , "WarriorNotIn"    )]
        public void Fight_ThrowsException_WhenInvalidName(string warrOne, string warrTwo)
        {
            arena.Enroll(new Warrior("Warrior", 80, 80));

            Assert.That(() => arena.Fight(warrOne, warrTwo), Throws.InvalidOperationException);
        }

        [Test]
        public void Fight_CorrectyDecreasesHealthPoints()
        {
            int initialHP = 80;
            Warrior attacker = new Warrior("Attacker", 50, initialHP);
            Warrior defender = new Warrior("Defender", 40, initialHP);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.That(attacker.HP, Is.EqualTo(initialHP - defender.Damage));
            Assert.That(defender.HP, Is.EqualTo(initialHP - attacker.Damage));
        }
    }
}
