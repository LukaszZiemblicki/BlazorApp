using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp.Shared.Common.DTOs;
using BlazorApp.Shared.Common.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Interface.Web.Business.Services
{
    public class ExchangeRateClientService : ClientServiceBase, IExchangeRateService
    {
        private readonly HttpClient _httpClient;

        public ExchangeRateClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ExchangeRateDTO> Get()
        {
            return await _httpClient.GetJsonAsync<ExchangeRateDTO>(CombineUrl("ExchangeRate/GetRates"));
        }
    }
}
