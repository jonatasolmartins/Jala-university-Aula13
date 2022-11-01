using Microsoft.Extensions.Options;

namespace MoneyExchange
{
    public class CurrencyFactory : ICurrencyFactory
    {
        private readonly List<CurrencyPrice> _PriceList;

        public CurrencyFactory
            (
               IOptions<List<CurrencyPrice>> options
            )
        {
            _PriceList = options.Value;
        }
        public CurrencyWallet CreateCurrency(Currency currency)
        {
            var currencyPrice = _PriceList.SingleOrDefault(x => x.CurrencyCode == currency.Code);
            return new CurrencyWallet(currency, currencyPrice.Price);
        }
    }

    public interface ICurrencyFactory 
    {
        CurrencyWallet CreateCurrency(Currency currency);
    }
}
