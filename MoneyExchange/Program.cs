using MoneyExchange;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<List<Currency>>(builder.Configuration.GetSection("Currency"));
builder.Services.Configure<List<CurrencyPrice>>(builder.Configuration.GetSection("CurrencyPrice"));
builder.Services.AddSingleton<ICurrencyFactory, CurrencyFactory>();
builder.Services.AddScoped<IMasterWallet, MasterWallet>();
builder.Services.AddSingleton<IExchangeService, ExchangeService>();
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
