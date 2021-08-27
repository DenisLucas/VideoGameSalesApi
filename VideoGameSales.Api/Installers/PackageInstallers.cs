using System;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoGameSales.Core.FIlters;

namespace VideoGameSales.Api.Installers
{
    public class PackageInstallers : IInstallers
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            addMediatR(services);
            fluentValidation(services);
            addAutoMaper(services);
        }

        private void addMediatR(IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.Load("VideoGameSales.Core"));
        }
        private void fluentValidation(IServiceCollection services)
        {
            services.AddMvc(options =>
                options.Filters.Add<ValidationFilter>());
            services.AddFluentValidation(mvcConfiguration=> mvcConfiguration.RegisterValidatorsFromAssembly(AppDomain.CurrentDomain.Load("VideoGameSales.Core")));
        }
        private void addAutoMaper(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.Load("VideoGameSales.Domain"));

        }
    }
}
