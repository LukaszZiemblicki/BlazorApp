using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlazorApp.Shared.Common.DTOs
{
    public class ExchangeRateDTO
    {
        [JsonPropertyName("no")]
        public string ID { get; set; }

        [JsonPropertyName("effectiveDate")]
        public string Date { get; set; }

        [JsonPropertyName("rates")]
        public IEnumerable<ExchangeRateItemDTO> Items { get; set; }
    }
}
