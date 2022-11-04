using Microsoft.Extensions.Options;

namespace MoneyExchange
{
    public  class CurrencyFactory : ICurrencyFactory
    {
        private readonly List<CurrencyPrice> _PriceList;

        public CurrencyFactory
            (
               IOptions<List<CurrencyPrice>> options
            )
        {
            _PriceList = options.Value;
        }

        public ICurrencyWallet CreateCryptoWallet(Currency currency)
        {
            return new CryptoWallet(currency, 200);
        }

        public ICurrencyWallet CreateFiatWallet(Currency currency)
        {
            var currencyPrice = _PriceList.SingleOrDefault(x => x.CurrencyCode == currency.Code);
            return new FiatWallet(currency, currencyPrice.Price);
        }

    }

    public interface ICurrencyFactory 
    {
        ICurrencyWallet CreateFiatWallet(Currency currency);
        ICurrencyWallet CreateCryptoWallet(Currency currency);
    }
}
