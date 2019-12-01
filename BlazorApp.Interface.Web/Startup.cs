using BlazorApp.Interface.Web.Business.Services;
using BlazorApp.Interface.Web.ViewModels;
using BlazorApp.Shared.Common.Interfaces;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp.Interface.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new System.Collections.Generic.Dictionary<string, string> { { "key", "value" } })
                .Build();
            services.AddSingleton(config);

            services.AddTransient<IExchangeRateService, ExchangeRateClientService>();
            services.AddTransient<IExchangeRateAlertService, ExchangeRateAlertClientService>();
            services.AddTransient<ExchangeRatePageViewModel>();
            services.AddTransient<ExchangeRateAlertPageViewModel>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
