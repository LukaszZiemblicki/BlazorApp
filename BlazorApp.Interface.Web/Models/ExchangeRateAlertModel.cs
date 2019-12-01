using System.ComponentModel.DataAnnotations;
using BlazorApp.Shared.Common.Enums;

namespace BlazorApp.Interface.Web.Models
{
    public class ExchangeRateAlertModel
    { 
        public int ID { get; set; }

        [Required]
        public CurrencyType Currency { get; set; }

        [Required]
        public decimal? Value { get; set; }

        public string Comment { get; set; }
    }
}
