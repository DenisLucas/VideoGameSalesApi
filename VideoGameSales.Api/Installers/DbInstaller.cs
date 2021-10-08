
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoGameSales.Infrastructure;
using VideoGameSales.Util.Helpers;

namespace VideoGameSales.Api.Installers
{
    public class DbInstaller : IInstallers
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
             services.AddDbContext<VideoGameSalesDbContext>(
                 options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"),
                 b => b.MigrationsAssembly("VideoGameSales.Infrastructure"))
            );

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<VideoGameSalesDbContext>()
                .AddDefaultTokenProviders();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<UrlHelpers>(provider =>
            {
                var acessor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = acessor.HttpContext.Request;
                var absolutUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent(), "/");
                return new UrlHelpers(absolutUri);
            }
            );
            
            
        }
    }
}
