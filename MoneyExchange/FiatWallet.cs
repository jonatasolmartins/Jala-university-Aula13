namespace MoneyExchange
{
    public class FiatWallet : ICurrencyWallet
    {
        public Currency Money { get; init; }
        public decimal Price { get; private set; }
        public decimal Balance { get; private set; }
        public decimal LockedBalance { get; private set; }

        public FiatWallet(Currency money, decimal price)
        {
            Money = Enum.IsDefined(typeof(FiatCode),money.Code) ? money : throw new InvalidDataException();
            Price = price;
        }

        public void LockBalance(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                LockedBalance += amount;
            }
        }

        public void UnlockBalance(decimal amount)
        {
            if (amount <= LockedBalance)
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
