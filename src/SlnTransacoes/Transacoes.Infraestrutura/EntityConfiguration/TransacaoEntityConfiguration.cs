using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;

namespace Transacoes.Infraestrutura.EntityConfiguration
{

    public class TransacaoEntityConfiguration : EntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            // Nome da tabela
            builder.ToTable("Transacoes");

            // Chave primária
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("TransacaoId");

            builder.Property(t => t.DataTransacao)
                   .IsRequired();

            builder.Property(t => t.Valor)
                   .IsRequired();

            builder.Property(t => t.IsCredito)
                .IsRequired()
                .HasColumnName("Credito");

            builder.Property(t => t.Descricao)
                .IsRequired();

            builder.Property(t => t.CriadoPorId)
                .IsRequired()
                .HasColumnName("CriadoPor");

            builder.Property(t => t.CriadoEm)
                .IsRequired();

            builder.Property(t => t.ModificadoPor);

            builder.Property(t => t.ModificadoEm);

            builder.Property(t => t.ExcluidoPor);

            builder.Property(t => t.ExcluidoEm);

            builder.Property(t => t.Excluido);

            builder.Property(t => t.CategoriaId)
                   .IsRequired();

            builder.Property(t => t.MetodoPagamentoId)
                    .IsRequired();

            builder.Ignore(t => t.MetodoPagamento);
            builder.Ignore(t => t.Categoria);
        }
    }
}
