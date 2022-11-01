namespace MoneyExchange
{
    public interface IExchangeService
    {
        void ExchangeMoney(IMasterWallet wallet, Currency outgoingCurrency, Currency incomingCurrency, decimal amount);
    }
}