using System.Threading.Tasks;
using BlazorApp.Shared.Common.DTOs;
using BlazorApp.Shared.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Interface.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {
        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeRateController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        [HttpGet("GetRates")]
        public async Task<ActionResult<ExchangeRateDTO>> GetRates()
        {
            return await _exchangeRateService.Get();
        }
    }
}
