namespace BankSystem
{
    public class BankAccount : IAccount
    {
        private decimal _balance;

        public BankAccount(int startingBalance)
        {
            _balance = startingBalance;
        }

        public decimal Balance => _balance;

        public void Deposit(decimal amount) => _balance += amount;

        public void Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}