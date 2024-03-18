using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using BlazorCrypto.Models;


namespace BlazorCrypto.Services;

public class CoinGeckoService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://api.coingecko.com/api/v3";

    public CoinGeckoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CryptocurrencyInfo>?> GetCryptocurrencyDataAsync()
    {
        var url = $"{BaseUrl}/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=8&page=1&sparkline=false";
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<CryptocurrencyInfo>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result ?? new List<CryptocurrencyInfo>(); // Return an empty list if result is null
        }

        return new List<CryptocurrencyInfo>(); // Return an empty list if the status code is not successful
    }

}