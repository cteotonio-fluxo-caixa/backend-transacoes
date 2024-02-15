using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;
using Transacoes.Infraestrutura;
using Transacoes.Infraestrutura.Repositorios;

namespace Transacoes.Testes.Infra
{
    public class EFSaldoDiaRepositorioTeste
    {
        [Theory(DisplayName ="Adicionar Saldo do Dia - Deve adiconar")]
        [InlineData("2024-02-06", 1000)]
        [InlineData("2024-02-05", -50)]
        public void Adicionar_SaldoDia_DeveAdicionar(DateTime dataSaldo, decimal saldo)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Teste_SaldoDia")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var repositorio = new EFSaldoDiaRepositorio(context);

                // Arrange
                var saldoDia = new SaldoDia { Id = Guid.NewGuid(), DataSaldo = dataSaldo, Saldo = saldo };

                // Act
                repositorio.Adicionar(saldoDia);

                // Assert
                var saldoDiaAdicionado = context.Set<SaldoDia>().FirstOrDefault(m => m.Id == saldoDia.Id);
                saldoDiaAdicionado.Should().NotBeNull();
                saldoDiaAdicionado.DataSaldo.Should().Be(saldoDia.DataSaldo);
            }
        }

        [Theory(DisplayName = "Adicionar Saldo Dia Duplicado - Deve lancar exceção")]
        [InlineData("2024-02-06", 1000, "2024-02-06", 2000)]
        [InlineData("2024-02-05", 10, "2024-02-06", -50)]
        public void Adicionar_SaldoDiaDuplicado_DeveLancarExcecao(string dataExistente, decimal saldoExistente, string novaData, decimal novoSaldo)
        {
            var connectionString = new SqliteConnectionStringBuilder { DataSource = ":memory:" }.ToString();
            var connection = new SqliteConnection(connectionString);
            connection.Open();
            var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite(connection).Options;

            using (var context = new AppDbContext(options))
            {
                if (context.Database.EnsureCreated())
                {
                    var repositorio = new EFSaldoDiaRepositorio(context);

                    // Arrange
                    var saldoDiaExistente = new SaldoDia { Id = Guid.NewGuid(), DataSaldo = DateTime.Parse(dataExistente), Saldo = saldoExistente };
                    repositorio.Adicionar(saldoDiaExistente);
                    var novoSaldoDia = new SaldoDia { Id = saldoDiaExistente.Id, DataSaldo = DateTime.Parse(novaData), Saldo = novoSaldo }; // Tenta adicionar um saldo para a mesma data

                    // Act & Assert
                    var exception = Assert.Throws<InvalidOperationException>(() => repositorio.Adicionar(novoSaldoDia));
                    Assert.Contains("The instance of entity type 'SaldoDia' cannot be tracked because another instance with the same key value for {'Id'} is already being tracked", exception.Message);
                }
            }
        }
    }
}
