using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;

namespace Transacoes.Infraestrutura.EntityConfiguration
{
    public class SaldoDiaEntityConfiguration : EntityTypeConfiguration<SaldoDia>
    {
        public void Configure(EntityTypeBuilder<SaldoDia> builder)
        {
            // Nome da tabela
            builder.ToTable("SaldoDia");

            // Chave primária
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("SaldoDiaId");

            builder.Property(t => t.DataSaldo)
                .IsRequired()
                .HasColumnType("DATE");

            builder.HasIndex(x => x.DataSaldo).IsUnique();

            builder.Property(t => t.Saldo)
                .IsRequired()
                .HasPrecision(18,2);
        }
    }
}
