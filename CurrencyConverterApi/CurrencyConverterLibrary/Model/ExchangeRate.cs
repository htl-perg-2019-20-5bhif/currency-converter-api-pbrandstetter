namespace CurrencyConverterLibrary.Model
{
    public class ExchangeRate
    {
        private decimal rate;

        public string Currency { get; set; }

        public decimal Rate
        {
            get { return rate; }
            set { rate = decimal.Round(value, 2); }
        }
    }
}
