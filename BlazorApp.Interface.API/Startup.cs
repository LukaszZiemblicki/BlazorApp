using System;
using BlazorApp.Interface.API.Business.Data;
using BlazorApp.Interface.API.Business.Services;
using BlazorApp.Interface.API.Core.Consts;
using BlazorApp.Shared.Common.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlazorApp.Interface.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddDefaultPolicy( b =>
                 {
                     b.AllowAnyOrigin();
                     b.AllowAnyHeader();
                     b.AllowAnyMethod();
                 });
            });

            services.AddHttpClient(ExchangeServiceConsts.HTTP_CLIENT_NAME, c =>
            {
                c.BaseAddress = new Uri(ExchangeServiceConsts.HTTP_CLIENT_URL);
                c.DefaultRequestHeaders.Add("format", "json");
            });

            services.AddDbContext<BlazorAppContext>(o =>
                o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IExchangeRateService, ExchangeRateService>();
            services.AddTransient<IExchangeRateAlertService, ExchangeRateAlertService>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
