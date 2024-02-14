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
    public class MetodoPagamentoEntityConfiguration : EntityTypeConfiguration<MetodoPagamento>
    {
        public void Configure(EntityTypeBuilder<MetodoPagamento> builder)
        {
            // Nome da tabela
            builder.ToTable("MetodosPagamento");

            // Chave primária
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("MetodoPagamentoId");

            builder.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
