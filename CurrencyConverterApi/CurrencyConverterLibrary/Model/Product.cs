namespace CurrencyConverterLibrary.Model
{
    public class Product
    {
        private decimal price;

        public string Description { get; set; }

        public string Currency { get; set; }

        public decimal Price
        {
            get { return price; }
            set { price = decimal.Round(value, 2); }
        }
    }
}
