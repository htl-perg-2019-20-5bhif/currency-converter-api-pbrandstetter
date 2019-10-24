using System.Threading.Tasks;

namespace CurrencyConverterApi.Services
{
    public interface IFileReader
    {
        Task<(string exchangeRateFileContent, string productPricesFileContent)> ReadCsvAsync();
    }
}
