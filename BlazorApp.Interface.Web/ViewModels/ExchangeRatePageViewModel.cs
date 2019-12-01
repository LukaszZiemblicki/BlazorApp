using System;
using System.Threading.Tasks;
using BlazorApp.Shared.Common.DTOs;
using BlazorApp.Shared.Common.Interfaces;

namespace BlazorApp.Interface.Web.ViewModels
{
    public class ExchangeRatePageViewModel
    {
        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeRatePageViewModel(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        public ExchangeRateDTO Model { get; set; } = new ExchangeRateDTO();

        public async Task LoadAsync()
        {
            this.Model = await _exchangeRateService.Get();
        }
    }
}
