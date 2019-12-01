using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Shared.Common.DTOs;
using BlazorApp.Shared.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Interface.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExchangeRateAlertController : ControllerBase
    {
        private readonly IExchangeRateAlertService _exchangeRateAlertService;

        public ExchangeRateAlertController(IExchangeRateAlertService exchangeRateAlertService)
        {
            _exchangeRateAlertService = exchangeRateAlertService;
        }

        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<ExchangeRateAlertDTO>>> List()
        {
            IEnumerable<ExchangeRateAlertDTO> alertEnumerable = await _exchangeRateAlertService.List();
            return alertEnumerable.ToList();
        }

        [HttpPost("Create")]
        public async Task<ActionResult<bool>> Create(ExchangeRateAlertDTO alertDto)
        {
            await _exchangeRateAlertService.Create(alertDto);
            return true;
        }

        [HttpPost("Update")]
        public async Task<ActionResult<bool>> Update(ExchangeRateAlertDTO alertDto)
        {
            await _exchangeRateAlertService.Update(alertDto);
            return true;
        }

        [HttpPost("Delete/{alertId}")]
        public async Task<ActionResult<bool>> Delete(int alertId)
        {
            await _exchangeRateAlertService.Delete(alertId);
            return true;
        }
    }
}
