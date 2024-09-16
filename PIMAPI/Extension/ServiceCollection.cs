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
            services.AddScoped<IColaboratorService, ColaboratorService>();
            services.AddScoped<IProductionService, ProductionService>();
            services.AddScoped<ISupplyService, SupplyService>();
            services.AddScoped<ISalesService, SalesService>();
            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {

            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IColaboratorRepository, ColaboratorRepository>();
            services.AddScoped<ISupplyRepository, SupplyRepository>();
            services.AddScoped<IProductionRepository, ProductionRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            return services;
        }


    }
}
