namespace CurrencyConverterLibrary.Model
{
    public class PriceDto
    {
        private decimal price;

        public PriceDto(decimal price)
        {
            price = decimal.Round(price, 2);
        }

        public decimal Price
        {
            get { return price; }
            set { price = decimal.Round(value, 2); }
        }
    }
}
