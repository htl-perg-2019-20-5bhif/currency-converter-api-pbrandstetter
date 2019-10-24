using CurrencyConverterLibrary.Model;
using System.Collections.Generic;
using System.Globalization;

namespace CurrencyConverterLibrary
{
    public class ParseCsv
    {
        public List<ExchangeRate> CsvExchangeRateParser(string csvContent)
        {
            List<ExchangeRate> exchangeRates = new List<ExchangeRate>();
            List<string> lines = new List<string>(csvContent.Trim().Replace("\r", string.Empty).Split('\n'));
            lines.RemoveAt(0);
            foreach (string s in lines)
            {
                string[] split = s.Split(',');
                exchangeRates.Add(new ExchangeRate
                {
                    Currency = split[0],
                    Rate = decimal.Parse(split[1], CultureInfo.InvariantCulture)
                });
            }
            return exchangeRates;
        }

        public List<Product> CsvProductParser(string csvContent)
        {
            List<Product> products = new List<Product>();
            List<string> lines = new List<string>(csvContent.Trim().Replace("\r", string.Empty).Split('\n'));
            lines.RemoveAt(0);
            foreach (string s in lines)
            {
                string[] split = s.Split(',');
                products.Add(new Product
                {
                    Description = split[0],
                    Currency = split[1],
                    Price = decimal.Parse(split[2], CultureInfo.InvariantCulture)
                });
            }
            return products;
        }
    }
}
