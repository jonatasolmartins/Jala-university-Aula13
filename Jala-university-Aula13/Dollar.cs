namespace Jala_university_Aula13
{
    public class Dollar : ICurrency
    {
        public decimal Price { get; set; }
        public string Code { get; set; } = "USD";
        public Dollar(decimal price)
        {
            Price = price;
        }
    }
}
