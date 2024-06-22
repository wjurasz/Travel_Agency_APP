using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SzkolenieTechniczneStorage
{
    public class TravelAgencyTicketDbContextFactory : IDesignTimeDbContextFactory<TravelAgencyTicketDbContext>
    {
        public TravelAgencyTicketDbContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var builder = new DbContextOptionsBuilder<TravelAgencyTicketDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new TravelAgencyTicketDbContext(builder.Options);
        }
    }
}
