using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Interface.Web.Mappers;
using BlazorApp.Interface.Web.Models;
using BlazorApp.Shared.Common.Interfaces;

namespace BlazorApp.Interface.Web.ViewModels
{
    public class ExchangeRateAlertPageViewModel
    {
        private readonly IExchangeRateAlertService _exchangeRateAlertService;

        public List<ExchangeRateAlertModel> Model { get; set; } = new List<ExchangeRateAlertModel>();

        public ExchangeRateAlertModel ItemToCreate { get; set; } = new ExchangeRateAlertModel();

        public ExchangeRateAlertPageViewModel(IExchangeRateAlertService exchangeRateAlertService)
        {
            _exchangeRateAlertService = exchangeRateAlertService;
        }

        public async Task LoadAsync()
        {
            var result = await _exchangeRateAlertService.List();
            Model = result
                .ToModelList()
                .ToList();
        }

        public async Task CreateAsync()
        {
            await _exchangeRateAlertService.Create(ItemToCreate.ToDTO());
            ItemToCreate = new ExchangeRateAlertModel();
            await LoadAsync();
        }

        public async Task UpdateAsync(ExchangeRateAlertModel alertModel)
        {
            await _exchangeRateAlertService.Update(alertModel.ToDTO());
            await LoadAsync();
        }

        public async Task DeleteAsync(int alertId)
        {
            await _exchangeRateAlertService.Delete(alertId);
            await LoadAsync();
        }
    }
}
