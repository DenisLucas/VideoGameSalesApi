using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VideoGameSales.Api.Installers
{
    public interface IInstallers
    {
        void InstallServices(IServiceCollection services,IConfiguration configuration);
    }
}
