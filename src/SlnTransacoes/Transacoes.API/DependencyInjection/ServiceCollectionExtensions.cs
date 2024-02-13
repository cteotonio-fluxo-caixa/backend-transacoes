using Microsoft.EntityFrameworkCore;
using System;
using Transacoes.Aplicacao.Servicos;
using Transacoes.Core.Entities;
using Transacoes.Core.Repositories;
using Transacoes.Core.Services;
using Transacoes.Infraestrutura;
using Transacoes.Infraestrutura.Repositorios;

namespace Transacoes.API.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransacaoApplication(this IServiceCollection services)
        {
            services.AddScoped<ITransacaoAppService, TransacaoAppService>();
            services.AddScoped<ITransacaoServico, TransacaoServico>();
            services.AddScoped<ITransacaoRepositorio, EFTransacaoRepository>();
            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

            return services;
        }
    }
}
