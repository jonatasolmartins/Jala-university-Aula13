namespace Jala_university_Aula13
{
    public interface ICurrencyFactory
    {
        public ICurrency CreateCurrency(CurrencyCode code);
    }
}
