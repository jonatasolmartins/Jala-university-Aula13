namespace MoneyExchange
{
    public interface ICurrencyWallet
    {
        decimal Balance { get; }
        decimal LockedBalance { get; }
        Currency Money { get; init; }
        decimal Price { get; }

        decimal GetBalance();
        decimal GetTotalBalance();
        void LockBalance(decimal amount);
        void UnlockBalance(decimal amount);
        void UpdateBalance(decimal amount);
        void WithDraw(decimal amount);
    }
}