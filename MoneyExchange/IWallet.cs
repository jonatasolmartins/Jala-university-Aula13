﻿namespace MoneyExchange
{
    public interface IWallet
    {
        void AddCurrency(Currency currency);
        void UpdateBalance(Currency currency, decimal amount);
        decimal WithDraw(Currency currency, decimal amount);
        public bool HasCurrency(Currency currency);
    }
}