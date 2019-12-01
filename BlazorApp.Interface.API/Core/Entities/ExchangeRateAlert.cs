using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Interface.API.Core.Entities
{
    public class ExchangeRateAlert
    {
        [Key]
        public int ID { get; set; }

        public int CurrencyDICId { get; set; }

        public decimal Value { get; set; }

        public string Comment { get; set; }


        public CurrencyDIC Currency { get; set; }
    }
}
