using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Shared.Common.DTOs;

namespace BlazorApp.Shared.Common.Interfaces
{
    public interface IExchangeRateAlertService
    {
        Task<IEnumerable<ExchangeRateAlertDTO>> List();
        Task Create(ExchangeRateAlertDTO alert);
        Task Update(ExchangeRateAlertDTO alert);
        Task Delete(int alertId);
    }
}
