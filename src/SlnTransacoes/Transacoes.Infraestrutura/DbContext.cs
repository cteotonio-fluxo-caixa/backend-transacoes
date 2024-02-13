using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Transacoes.Core.Entities;
using Transacoes.Infraestrutura.EntityConfiguration;

namespace Transacoes.Infraestrutura
{
    public class AppDbContext : DbContext
    {
        public DbSet<Transacao> TransacaoEntity { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações usando Fluent API
            new TransacaoEntityConfiguration().Configure(modelBuilder.Entity<Transacao>());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransacaoEntityConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
