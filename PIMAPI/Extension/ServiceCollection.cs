using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PIMAPI.Application.Infra.Data.Repository;
using PIMAPI.Application.Interfaces;
using PIMAPI.Application.Services;

namespace PIMAPI.Extension
{
    public static class ServiceCollection
    {

        public static IServiceCollection AddFeatureServices(this IServiceCollection services)
        {
            services.AddServices();
            services.AddRepository();
            services.AddControllers();
           
            
        
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
             

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IColaboradorService, ColaboradorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IFornecedoresService, FornecedoresService>();
            services.AddScoped<IVendasService, VendasService>();
            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {

            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<IFornecedoresRepository, FornecedoresRepository>();
            services.AddScoped<IProductionRepository, ProdutoRepository>();
            services.AddScoped<IVendasRepository, VendasRepository>();
            return services;
        }


    }
}
