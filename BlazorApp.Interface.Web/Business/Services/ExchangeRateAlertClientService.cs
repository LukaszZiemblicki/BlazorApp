using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp.Shared.Common.DTOs;
using BlazorApp.Shared.Common.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Interface.Web.Business.Services
{
    public class ExchangeRateAlertClientService : ClientServiceBase, IExchangeRateAlertService
    {
        private readonly HttpClient _httpClient;

        public ExchangeRateAlertClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Create(ExchangeRateAlertDTO alert)
        {
            await _httpClient.PostJsonAsync(CombineUrl("ExchangeRateAlert/Create"), alert);
        }

        public async Task Delete(int alertId)
        {
            await _httpClient.PostAsync(CombineUrl($"ExchangeRateAlert/Delete/{alertId}"), null);
        }

        public async Task<IEnumerable<ExchangeRateAlertDTO>> List()
        {
            return await _httpClient.GetJsonAsync<IEnumerable<ExchangeRateAlertDTO>>(CombineUrl("ExchangeRateAlert/List"));
        }

        public async Task Update(ExchangeRateAlertDTO alert)
        {
            await _httpClient.PostJsonAsync(CombineUrl("ExchangeRateAlert/Update"), alert);
        }
    }
}
