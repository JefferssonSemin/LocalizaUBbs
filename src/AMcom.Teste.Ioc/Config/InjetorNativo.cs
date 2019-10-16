using System;
using AMcom.Teste.Dal.Interfaces;
using AMcom.Teste.DAL;
using AMcom.Teste.Service.Interfaces;
using AMcom.Teste.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AMcom.Teste.Ioc.Config
{
    public static class InjetorNativo
    {
        public static void RegistraDependencias(this IServiceCollection services)
        {
            services.AddScoped<IUbsService, UbsService>();
            services.AddScoped<IUbsRepository, UbsRepository>();
        }
    }
}
