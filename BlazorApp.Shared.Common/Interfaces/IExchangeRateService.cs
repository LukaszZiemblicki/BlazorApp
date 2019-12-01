using System;
using System.Threading.Tasks;
using BlazorApp.Shared.Common.DTOs;

namespace BlazorApp.Shared.Common.Interfaces
{
    public interface IExchangeRateService
    {
        Task<ExchangeRateDTO> Get();
    }
}
