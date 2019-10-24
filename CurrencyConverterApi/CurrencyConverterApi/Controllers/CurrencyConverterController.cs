using CurrencyConverterApi.Services;
using CurrencyConverterLibrary;
using CurrencyConverterLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyConverterApi.Controllers
{
    [ApiController]
    public class CurrencyConverterController : ControllerBase
    {
        private readonly IFileReader fileReader;

        public CurrencyConverterController(IFileReader fileReader)
        {
            this.fileReader = fileReader;
        }

        [HttpGet]
        [Route("api/products/{productDesc}/price")]
        public async Task<PriceDto> GetAsync([FromRoute] string productDesc, [FromQuery] string targetCurrency)
        {
            CurrencyConverter cc = new CurrencyConverter();
            ParseCsv parser = new ParseCsv();

            var (exchangeRateFileContent, productPricesFileContent) = await fileReader.ReadCsvAsync();

            List<ExchangeRate> exchangeRates = parser.CsvExchangeRateParser(exchangeRateFileContent);
            List<Product> products = parser.CsvProductParser(productPricesFileContent);

            return new PriceDto(cc.Convert(products.Find(p => p.Description == productDesc), exchangeRates, targetCurrency));
        }
    }
}
