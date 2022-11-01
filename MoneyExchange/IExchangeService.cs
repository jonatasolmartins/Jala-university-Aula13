namespace MoneyExchange
{
    public interface IExchangeService
    {
        void ExchangeMoney(IWallet wallet, Currency outgoingCurrency, Currency incomingCurrency, decimal amount);
    }
}