using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using KOI.Blueprint.Infrastructure.EntityFrameworkCore;

namespace KOI.Blueprint.API.Infrastructure.Factories
{
    public class KOISystemContextFactory : IDesignTimeDbContextFactory<KOISystemContext>
    {
        public KOISystemContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<KOISystemContext>();
            var connectionStr = config.GetConnectionString("DefaultConnection"); 
            optionsBuilder.UseNpgsql(connectionStr, npgsql =>
            {
                npgsql.MigrationsAssembly("KOI.Blueprint.API");
            });

            return new KOISystemContext(optionsBuilder.Options);
        }
    }
}
