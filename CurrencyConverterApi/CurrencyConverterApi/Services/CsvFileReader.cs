using CurrencyConverterApi.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CurrencyConverterApi.Services
{
    public class CsvFileReader : IFileReader
    {
        private readonly IConfiguration config;
        private readonly ILogger<CurrencyConverterController> logger;

        public CsvFileReader(IConfiguration config, ILogger<CurrencyConverterController> logger)
        {
            this.config = config;
            this.logger = logger;
        }

        public async Task<(string exchangeRateFileContent, string productPricesFileContent)> ReadCsvAsync()
        {
            string exchangeRateFileContent, productPricesFileContent;
            WebClient webClient = new WebClient();

            webClient.DownloadFile(config["exchangeRateFileUrl"], config["exchangeRateLocalName"]);
            webClient.DownloadFile(config["productPricesFileUrl"], config["productPricesLocalName"]);

            try
            {
                string exchangeRateFileUrl = config["exchangeRateLocalName"];
                exchangeRateFileContent = await File.ReadAllTextAsync(exchangeRateFileUrl);

                string productPricesFileUrl = config["productPricesLocalName"];
                productPricesFileContent = await File.ReadAllTextAsync(productPricesFileUrl);
            }
            catch (FileNotFoundException ex)
            {
                logger.LogCritical(ex, "File not found!");
                throw;
            }
            return (exchangeRateFileContent, productPricesFileContent);
        }
    }
}
