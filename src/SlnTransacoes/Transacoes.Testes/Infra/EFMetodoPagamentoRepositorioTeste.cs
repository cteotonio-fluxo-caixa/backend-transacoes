using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;
using Transacoes.Core.Repositories;
using Transacoes.Infraestrutura;
using Transacoes.Infraestrutura.Repositorios;

namespace Transacoes.Testes.Infra
{
    public class EFMetodoPagamentoRepositorioTeste
    {
        [Theory(DisplayName ="Adicionar Metodo de Pagamento Válido - Deve adicionar")]
        [InlineData("Cartão de Crédito")]
        [InlineData("Dinheiro")]
        public void Adicionar_MetodoPagamentoValido_DeveAdiconar(string nomeMetodoPagamento)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Teste_MetodoPagamento")
            .Options;

            using (var context = new AppDbContext(options))
            {
                var repositorio = new EFMetodoPagamentoRepositorio(context);
                var metodoPagamento = new MetodoPagamento(nomeMetodoPagamento, "Descrição - " + nomeMetodoPagamento);
    
                // Act
                repositorio.Adicionar(metodoPagamento);

                // Assert
                var metodoPagamentoDoBanco = context.Set<MetodoPagamento>().FirstOrDefault(m => m.Id == metodoPagamento.Id);
                metodoPagamentoDoBanco.Should().NotBeNull();
                metodoPagamentoDoBanco.Nome.Should().Be(nomeMetodoPagamento);
            }
        }

        [Theory(DisplayName = "Adicionar Metodo de Pagamento Inválido - Deve lançar exceção")]
        [InlineData(null)]
        public void Adicionar_MetodoPagamentoInvalido_DeveLancarExcecao(string nomeMetodoPagamento)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Teste_MetodoPagamento")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var repositorio = new EFMetodoPagamentoRepositorio(context);
                var metodoPagamento = new MetodoPagamento(nomeMetodoPagamento, "Descrição - " + nomeMetodoPagamento);

                // Act & Assert
                repositorio.Invoking(r => r.Adicionar(metodoPagamento)).Should().Throw<Microsoft.EntityFrameworkCore.DbUpdateException>();
            }
        }

        //[Fact]
        //public void Adicionar_DeveFalharQuandoNomeExcedeLimiteDeCaracteres()
        //{
        //    var options = new DbContextOptionsBuilder<AppDbContext>()
        //                  .UseInMemoryDatabase(databaseName: "Teste_MetodoPagamento")
        //                  .Options;

        //    using (var context = new AppDbContext(options))
        //    {
        //        var repository = new EFMetodoPagamentoRepositorio(context);
        //        var metodoPagamento = new MetodoPagamento("NomeComMaisDeVinteCaracteres", "Descrição do teste");

        //        // Act
        //        Action adicionarMetodoPagamento = () => repository.Adicionar(metodoPagamento);

        //        // Assert
        //        adicionarMetodoPagamento.Should().Throw<DbUpdateException>()
        //            .And.InnerException.Should().BeOfType<DbUpdateException>()
        //            .Which.InnerException.Message.Should().Contain("Nome");
        //    }
        //}
    }
}
