using BlazorApp.Interface.API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Interface.API.Business.Data
{
    public class BlazorAppContext : DbContext
    {
        public BlazorAppContext(DbContextOptions<BlazorAppContext> options) : base(options)
        {
        }

        public DbSet<ExchangeRateAlert> ExchangeRateAlerts { get; set; }
        public DbSet<CurrencyDIC> CurrencyDICs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyDIC>().ToTable("CurrencyDIC");
            modelBuilder.Entity<ExchangeRateAlert>().ToTable("ExchangeRateAlert");

        }
    }
}
