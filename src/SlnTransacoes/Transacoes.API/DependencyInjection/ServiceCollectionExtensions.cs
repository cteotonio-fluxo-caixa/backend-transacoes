using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using Transacoes.Aplicacao.Servicos;
using Transacoes.Core.Entities;
using Transacoes.Core.Repositories;
using Transacoes.Core.Services;
using Transacoes.Infraestrutura;
using Transacoes.Infraestrutura.Repositorios;

namespace Transacoes.API.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransacaoApplication(this IServiceCollection services)
        {
            services.AddScoped<ITransacaoAppService, TransacaoAppService>();
            services.AddScoped<ITransacaoServico, TransacaoServico>();
            services.AddScoped<ITransacaoRepositorio, EFTransacaoRepositorio>();

            services.AddScoped<IMetodoPagamentoAppService, MetodoPagamentoAppService>();
            services.AddScoped<IMetodoPagamentoServico, MetodoPagamentoServico>();
            services.AddScoped<IMetodoPagamentoRepositorio, EFMetodoPagamentoRepositorio>();

            services.AddScoped<ICategoriaTransacaoAppService, CategoriaTransacaoAppService>();
            services.AddScoped<ICategoriaTransacaoServico, CategoriaTransacaoServico>();
            services.AddScoped<ICategoriaTransacaoRepositorio, EFCategoriaTransacaoRepositorio>();

            services.AddScoped<ISaldoDiaRepositorio, EFSaldoDiaRepositorio>();
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
