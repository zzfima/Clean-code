using System.Transactions;

namespace BankSystem
{
    public interface ITransactionLogger
    {
        void Log(Transaction transaction);
    }
}
