using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VideoGameSales.Api.Installers
{
    public static class ExtensionInstaller
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installer = typeof(Startup).Assembly.GetExportedTypes().Where(x=> typeof(IInstallers).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstallers>().ToList();
            installer.ForEach(x=> x.InstallServices(services, configuration));
        }
    }
}
