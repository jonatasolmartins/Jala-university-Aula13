using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MoneyExchange.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ExchangeController : Controller
    {
        private readonly List<Currency> _MoneyOptions;
        private readonly IWallet _Wallet;
        private readonly IExchangeService _ExchangeService;

        public ExchangeController(IOptions<List<Currency>> options, IWallet wallet, IExchangeService exchangeService)
        {
            _MoneyOptions = options.Value;
            _Wallet = wallet;
            _ExchangeService = exchangeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var currency = _MoneyOptions[0];
            _Wallet.AddCurrency(currency);
            _Wallet.UpdateBalance(currency, 200);
            _Wallet.WithDraw(currency, 50);
            var otherCurrency = _MoneyOptions[1];
            _Wallet.AddCurrency(otherCurrency);
            _ExchangeService.ExchangeMoney(_Wallet, currency, otherCurrency, 70);
            return Ok(_Wallet.ToString());
        }
    }
}
