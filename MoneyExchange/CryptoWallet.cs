namespace MoneyExchange
{
    public class CryptoWallet : ICurrencyWallet
    {
        public decimal Balance => throw new NotImplementedException();

        public decimal LockedBalance => throw new NotImplementedException();

        public Currency Money { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

        public decimal Price { get; set; }

        public CryptoWallet(Currency money, decimal price)
        {
            Money = Enum.IsDefined(typeof(CryptoCode), money.Code) ? money : throw new InvalidDataException();
            Price = price;
        }
        public decimal GetBalance()
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalBalance()
        {
            throw new NotImplementedException();
        }

        public void LockBalance(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void UnlockBalance(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void UpdateBalance(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void WithDraw(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
