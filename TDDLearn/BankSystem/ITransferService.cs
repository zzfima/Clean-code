namespace BankSystem
{
    public interface ITransferService
    {
        void Transfer(IAccount from, IAccount to, decimal amount);
    }
}
