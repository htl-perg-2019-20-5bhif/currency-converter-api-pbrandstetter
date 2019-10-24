using CurrencyConverterLibrary.Model;
using System.Collections.Generic;

namespace CurrencyConverterLibrary
{
    public class CurrencyConverter
    {
        public decimal Convert(Product product, List<ExchangeRate> exchangeRates, string targetCurrency)
        {
            if (product.Currency == targetCurrency)
            {
                return product.Price;
            }
            if (targetCurrency == "EUR")
            {
                return product.Price / exchangeRates.Find(r => r.Currency == product.Currency).Rate;
            }
            return 0;
        }
    }
}
