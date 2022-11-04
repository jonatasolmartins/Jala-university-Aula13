namespace Jala_university_Aula13;

public class WalletService
{
    public Dictionary<string, ICurrency> Currencies { get; set; } = new();
    public int Id { get; set; }
    public const string WalletCurrency = "BRL";
    private readonly ICurrencyFactory _CurrencyFactory;

    public decimal Balance { get;  set; }

    public WalletService(ICurrencyFactory currencyFactory)
    {
        _CurrencyFactory = currencyFactory;
    }

    public Tuple<string, decimal> ExchangeMoney(string outgoingCurrency, decimal amount)
    {
        if (!Currencies.TryGetValue(outgoingCurrency,out var to))
        {
            throw new ArgumentException("Invalid currency");
        }

        if (amount < 50)
        {
            throw new InvalidOperationException("amount below expected");
        }

        if (amount > Balance)
        {
            throw new ArgumentException();
        }
       
        var total = (amount * to.Price) - 0.01M;
        
        return new Tuple<string, decimal>(outgoingCurrency, total);
    }
    
    public void AddToBalance(decimal amount)
    {
        Balance += amount;
    }

    public void AddCurrency(CurrencyCode code)
    {
       var newCurrency = _CurrencyFactory.CreateCurrency(code);
        Currencies.Add(code.ToString(), newCurrency);
    }

  }