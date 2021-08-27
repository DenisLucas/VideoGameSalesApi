
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoGameSales.Infrastructure;

namespace VideoGameSales.Api.Installers
{
    public class DbInstaller : IInstallers
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VideoGameSalesDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"),
                b => b.MigrationsAssembly("VideoGameSales.Infrastructure")
            
            ));
        }
    }
}
