using BlazorApp.Shared.Common.Enums;

namespace BlazorApp.Shared.Common.DTOs
{
    public class ExchangeRateAlertDTO
    {
        public int ID { get; set; }
        public CurrencyType Currency { get; set; }
        public decimal Value { get; set; }
        public string Comment { get; set; }
    }
}
