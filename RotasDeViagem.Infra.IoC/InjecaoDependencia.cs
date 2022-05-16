using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RotasDeViagem.Application.Interfaces;
using RotasDeViagem.Application.Mappings;
using RotasDeViagem.Application.Services;
using RotasDeViagem.Domain.Interfaces.Repository;
using RotasDeViagem.Infra.Data;

namespace RotasDeViagem.Infra.IoC
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IVooRepository, VooRepository>();
            services.AddScoped<IVooService, VooService>();
            services.AddAutoMapper(typeof(DomainDTOProfile));

            return services;
        }
    }
}
