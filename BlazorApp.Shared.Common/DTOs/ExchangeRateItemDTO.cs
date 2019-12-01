using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Common.DTOs
{
    public class ExchangeRateItemDTO
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("mid")]
        public decimal Value { get; set; }
    }
}
