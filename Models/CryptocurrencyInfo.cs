using System.Text.Json.Serialization;

namespace BlazorCrypto.Models;

public class CryptocurrencyInfo
{
    public string Id { get; set; } = "";
    public string Symbol { get; set; } = "";
    public string Name { get; set; } = "";
    
    [JsonPropertyName("image")]
    public string Image { get; set; } = "";
    
    
    [JsonPropertyName("current_price")]
    public double CurrentPrice { get; set; } = 0.0; // Matches "current_price"
    
    [JsonPropertyName("market_cap")]
    public double MarketCap { get; set; } = 0.0; // Matches "market_cap"
    
    [JsonPropertyName("price_change_percentage_24h")]
    public double PriceChangePercentage24H { get; set; } = 0.0; // Matches "price_change_percentage_24h"
}