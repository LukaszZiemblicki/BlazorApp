using System;
using System.Linq;
using BlazorApp.Interface.API.Core.Entities;
using BlazorApp.Shared.Common.Enums;

namespace BlazorApp.Interface.API.Business.Data
{
    public class DbInitializer
    {
        public static void Initialize(BlazorAppContext context)
        {
            context.Database.EnsureCreated();

            if (context.CurrencyDICs.Any())
                return;

            foreach(var currency in Enum.GetValues(typeof(CurrencyType)))
            {
                context.CurrencyDICs.Add(new CurrencyDIC
                {
                    ID=(int)currency,
                    Code=currency.ToString()
                });
            }

            context.SaveChanges();
        }
    }
}
