namespace Jala_university_Aula13
{

    public class Factory : ICurrencyFactory
    {
        Dictionary<string, decimal> Prices = new Dictionary<string, decimal>()
        {
            {"USD", 0.18M },
            {"BRL", 0.18M }
        };

        public ICurrency CreateCurrency(CurrencyCode code)
        {

            ICurrency currency = null;
            var price = Prices.FirstOrDefault(x => x.Key == code.ToString()).Value;
            switch (code)
            {
                case CurrencyCode.USD:
                    currency = new Dollar(price);
                    break;
                case CurrencyCode.BRL:
                    currency = new Real(price);
                    break;
                default:
                    break;
            }

            return currency;
        }
    }
}
