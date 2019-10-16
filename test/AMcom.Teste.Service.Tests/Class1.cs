using System;

namespace AMcom.Teste.Ioc
{
    public static class InjetorNativo
    {
        public static void ConfiguraDependencias(this IServiceCollection serviceCollection)
        {
            //Services
            serviceCollection.AddScoped<IUbsService, UbsService>();

            //Data
            serviceCollection.AddScoped<IUbsRepository, UbsRepository>();
        }
    }
}
