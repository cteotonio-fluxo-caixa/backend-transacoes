using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using Transacoes.Core.Entities;
using Transacoes.Infraestrutura.EntityConfiguration;

namespace Transacoes.Infraestrutura
{
    [ExcludeFromCodeCoverage]
    public class AppDbContext : DbContext
    {
        public DbSet<Transacao> TransacaoEntity { get; set; }
        public DbSet<MetodoPagamento> MetodoPagamentoEntity { get; set; }
        public DbSet<CategoriaTransacao> CategoriaTransacaoEntity { get; set; }
        public DbSet<SaldoDia> SaldoDiaEntity { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações usando Fluent API
            new TransacaoEntityConfiguration().Configure(modelBuilder.Entity<Transacao>());
            new MetodoPagamentoEntityConfiguration().Configure(modelBuilder.Entity<MetodoPagamento>());
            new CategoriaTransacaoEntityConfiguration().Configure(modelBuilder.Entity<CategoriaTransacao>());
            new SaldoDiaEntityConfiguration().Configure(modelBuilder.Entity<SaldoDia>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
