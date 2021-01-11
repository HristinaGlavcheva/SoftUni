using BankAccountTesting;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void AccountInicializeWithPositiveValue()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount(1000m);

            //Act //Assert
            Assert.That(bankAccount.Amount, Is.EqualTo(1000m));
        }

        [Test]
        public void DepositShouldAddMoney()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount(1000m);

            //Act
            bankAccount.Deposit(500m);

            //Assert
            Assert.That(bankAccount.Amount, Is.EqualTo(1500m));
        }

    }
}
