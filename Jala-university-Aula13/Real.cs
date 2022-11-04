namespace Jala_university_Aula13
{
    public class Real : ICurrency
    {
        public decimal Price { get; set; }
        public string Code { get; set; } = "BRL";

        public Real(decimal price)
        {
            Price = price;
        }
    }
}
