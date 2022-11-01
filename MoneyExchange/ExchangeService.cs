using Microsoft.Extensions.Options;

namespace MoneyExchange
{
    public class ExchangeService : IExchangeService
    {

        private const decimal TAX = 0.1M;
        private readonly List<CurrencyPrice> _PriceList;

        public ExchangeService(IOptions<List<CurrencyPrice>> options)
        {
            _PriceList = options.Value;
        }

        public void ExchangeMoney(IWallet wallet, Currency outgoingCurrency, Currency incomingCurrency, decimal amount)
        {
            if (!wallet.HasCurrency(outgoingCurrency)) throw new InvalidOperationException();

            if (!wallet.HasCurrency(incomingCurrency)) throw new InvalidOperationException();

            wallet.WithDraw(outgoingCurrency, amount);
            var priceExchance = _PriceList.SingleOrDefault(x => x.CurrencyCode == incomingCurrency.Code);

            wallet.UpdateBalance
                (
                    incomingCurrency,
                    (amount * priceExchance.Price - TAX)
                );
        }

    }
}
