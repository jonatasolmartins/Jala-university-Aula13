namespace MoneyExchange
{
    public class CurrencyWallet
    {
        public Currency Money { get; init; }
        public decimal Price { get; private set; }
        public decimal Balance { get; private set; }
        public decimal LockedBalance { get; private set; }

        public CurrencyWallet(Currency money, decimal price)
        {
            Money = money;
            Price = price;
        }

        public void LockBalance(decimal amount)
        {
            if(amount <= Balance)
            {
                Balance -= amount;
                LockedBalance += amount;
            }
        }

        public void UnlockBalance(decimal amount)
        {
            if(amount <= LockedBalance)
            {
                LockedBalance -= amount;
                Balance += amount;
            }

        }
        public decimal GetBalance()
        {
            return Balance - LockedBalance;
        }

        public decimal GetTotalBalance()
        {
            return Balance + LockedBalance;
        }

        public void UpdateBalance(decimal amount)
        {
            Balance += amount;
        }

        public void WithDraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new InvalidOperationException();
            }

            Balance -= amount;
        }

    }

}
