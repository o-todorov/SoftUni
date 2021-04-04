using NUnit.Framework;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private Item testItem;
        private BankVault bankVault;

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();

            item        = new Item("OwnerOne", "IdOne");
            testItem    = new Item("OwnerTwo", "IdTwo");
        }

        [Test]
        public void Ctor_CreatedDictionaryShouldNotBeNull()
        {
            Assert.That(bankVault.VaultCells.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Add_ShouldThrow_IfCellDoesNotExist()
        {
            Assert.That(()=>bankVault.AddItem("M1",item), Throws.ArgumentException);
        }

        [Test]
        public void Add_ShouldThrow_IfCellIsTaken()
        {
            bankVault.AddItem("A1", item);

            Assert.That(()=>bankVault.AddItem("A1",testItem), Throws.ArgumentException);
        }

        [Test]
        public void Add_ShouldThrow_IfItemWithSameIdAlreadyInTheSafe()
        {
            bankVault.AddItem("A1", item);

            Assert.That(()=>bankVault.AddItem("B1",item), Throws.InvalidOperationException);
        }

        [Test]
        public void Add_AddedItemSouldExistInTheSafe()
        {
            bankVault.AddItem("A1", item);

            CollectionAssert.Contains(bankVault.VaultCells.Values, item);
        }

        [Test]
        public void Remove_ShouldThrow_WhenGivenCellNotExist()
        {
            Assert.That(() => bankVault.RemoveItem("M1", item), Throws.ArgumentException);
        }

        [Test]
        public void Remove_ShouldThrow_WhenGivenCellIsEmpty()
        {
            bankVault.AddItem("A2", item);

            Assert.That(() => bankVault.RemoveItem("A1", item), Throws.ArgumentException);
        }

        [Test]
        public void Remove_ValueWhereItemIsRemovedShoulBeNull()
        {
            string cell = "A2";
            bankVault.AddItem(cell, item);
            bankVault.RemoveItem(cell, item);

            Assert.That(bankVault.VaultCells[cell], Is.Null);
        }

        [Test]
        public void Remove_RemovedItemShouldNotExistInVault()
        {
            string cell = "A2";
            bankVault.AddItem(cell, item);
            bankVault.RemoveItem(cell, item);

            CollectionAssert.DoesNotContain(bankVault.VaultCells.Values, item);
        }
    }
}