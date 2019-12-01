using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorApp.Interface.API.Core.Consts;
using BlazorApp.Shared.Common.DTOs;
using BlazorApp.Shared.Common.Interfaces;

namespace BlazorApp.Interface.API.Business.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ExchangeRateService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<ExchangeRateDTO> Get()
        {
            HttpClient client = _clientFactory.CreateClient(ExchangeServiceConsts.HTTP_CLIENT_NAME);
            var response = await client.GetAsync(ExchangeServiceConsts.EXCHANGE_RATE_PATH);
            IEnumerable<ExchangeRateDTO> result = await JsonSerializer.DeserializeAsync<IEnumerable<ExchangeRateDTO>>(await response.Content.ReadAsStreamAsync());
            return result?.FirstOrDefault();
        }
    }
}
