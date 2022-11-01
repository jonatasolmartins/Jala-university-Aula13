namespace MoneyExchange
{
    public class MasterWallet : IMasterWallet
    {
        private readonly ICurrencyFactory currencyFactory;

        public decimal Balance { get; set; }
        public List<CurrencyWallet> Currencies { get; private set; } = new();

        public MasterWallet(ICurrencyFactory currencyFactory)
        {
            this.currencyFactory = currencyFactory;
        }

        public decimal WithDraw(Currency currency, decimal amount)
        {
            if (amount < 50)
                throw new InvalidOperationException("amount must be greater than or equals to 50");

            var currentCurrency = Currencies.SingleOrDefault(x => x.Money.Code == currency.Code);

            if (currentCurrency == null) return 0;

            currentCurrency.WithDraw(amount);

            CalculateBalance();
            return amount;

        }

        public void UpdateBalance(Currency currency, decimal amount)
        {
            var currentCurrency = Currencies.SingleOrDefault(x => x.Money.Code == currency.Code);

            if (currentCurrency == null)
            {
                throw new InvalidOperationException("No such currency found in the wallet!");
            }

            currentCurrency.UpdateBalance(amount);
            CalculateBalance();
        }

        private void CalculateBalance()
        {
            Balance = Currencies.Select(x => x.GetBalance()).Sum();
        }

        public void AddCurrency(Currency currency)
        {
            var newCurrency = currencyFactory.CreateCurrency(currency);
            Currencies.Add(newCurrency);
        }

        public bool HasCurrency(Currency currency)
        {
            return Currencies.SingleOrDefault(x => x.Money.Code == currency.Code) != null;
        }
        public override string ToString()
        {
            var currencies = string.Join("/n", Currencies.Select(c => $": {c.Money.Symbol} {c.Balance} {c.Money.Code}"));
            return $"Currencies available: {currencies}/nTotal Balance: {Balance}";
        }

    }
}
