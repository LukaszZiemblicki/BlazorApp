using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Interface.API.Business.Data;
using BlazorApp.Interface.API.Core.Entities;
using BlazorApp.Shared.Common.DTOs;
using BlazorApp.Shared.Common.Enums;
using BlazorApp.Shared.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Interface.API.Business.Services
{
    public class ExchangeRateAlertService : IExchangeRateAlertService
    {
        private readonly BlazorAppContext _context;

        public ExchangeRateAlertService(BlazorAppContext context)
        {
            _context = context;
        }

        public async Task Create(ExchangeRateAlertDTO alert)
        {
            _context.ExchangeRateAlerts.Add(new ExchangeRateAlert
            {
                CurrencyDICId = (int)alert.Currency,
                Value = alert.Value,
                Comment = alert.Comment
            });

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExchangeRateAlertDTO>> List()
        {
            return await _context.ExchangeRateAlerts
                .Select(q =>
                    new ExchangeRateAlertDTO
                    {
                        ID = q.ID,
                        Value = q.Value,
                        Comment = q.Comment,
                        Currency = (CurrencyType)q.CurrencyDICId
                    })
                .ToListAsync();
        }

        public async Task Update(ExchangeRateAlertDTO alert)
        {
            ExchangeRateAlert entity = _context
                   .ExchangeRateAlerts
                   .FirstOrDefault(q => q.ID == alert.ID);

            if (entity == null)
                return;

            entity.CurrencyDICId = (int)alert.Currency;
            entity.Comment = alert.Comment;
            entity.Value = alert.Value;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int alertId)
        {
            ExchangeRateAlert alert = _context
                .ExchangeRateAlerts
                .FirstOrDefault(q => q.ID == alertId);

            if (alert == null)
                return;

            _context.ExchangeRateAlerts.Remove(alert);
            await _context.SaveChangesAsync();
        }
    }
}
