using BankSystem;

namespace BankTest
{
    public class UnitTestBankAccount
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestInitialBalanceZero()
        {
            IAccount account = new BankAccount(0);
            Assert.That(account.Balance == 0);
        }

        [Test]
        public void TestInitialBalanceTenThousand()
        {
            IAccount account = new BankAccount(10000);
            Assert.That(account.Balance == 10000);
        }

        [Test]
        public void TestDepositTenThousand()
        {
            IAccount account = new BankAccount(123);
            account.Deposit(10000);
            Assert.That(account.Balance == 10123);
        }

        [Test]
        public void TestDepositTwentyThousand()
        {
            IAccount account = new BankAccount(123);
            account.Deposit(20000);
            Assert.That(account.Balance == 20123);
        }
    }
}
