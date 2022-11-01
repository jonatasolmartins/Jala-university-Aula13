namespace MoneyExchange
{
    public struct Currency
    {
        public string Symbol { get; init; }
        public string Code { get; init; }

        public Currency(string symbol, string code)
        {
            Symbol = symbol;
            Code = code;
        }
    }

}
