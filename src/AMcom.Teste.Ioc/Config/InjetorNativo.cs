using AMcom.Teste.Dal.Interfaces;
using AMcom.Teste.DAL.Repository;
using AMcom.Teste.Service.Interfaces;
using AMcom.Teste.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AMcom.Teste.Ioc.Config
{
    public static class InjetorNativo
    {
        /// <summary>
        /// Carrega dependências do sistema, como o service e o repository e demais classes que possam ser injetadas.
        /// </summary>
        /// <param name="services"></param>
        public static void RegistraDependencias(this IServiceCollection services)
        {
            services.AddScoped<IUbsService, UbsService>();
            services.AddScoped<IUbsRepository, UbsRepository>();
        }
    }
}