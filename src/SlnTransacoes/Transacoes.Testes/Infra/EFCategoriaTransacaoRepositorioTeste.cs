using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;
using Transacoes.Infraestrutura.Repositorios;
using Transacoes.Infraestrutura;
using FluentAssertions;

namespace Transacoes.Testes.Infra
{
    public class EFCategoriaTransacaoRepositorioTeste
    {
        [Theory(DisplayName = "Adicionar Categoria Transação Válida - Deve adicionar")]
        [InlineData("Alimentação")]
        [InlineData("Lazer")]
        public void Adicionar_CategoriaTransacaoValida_DeveAdiconar(string nomeCategoriaTransacao)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Teste_CategoriaTransacao")
            .Options;

            using (var context = new AppDbContext(options))
            {
                var repositorio = new EFCategoriaTransacaoRepositorio(context);
                var categoriaTransacao = new CategoriaTransacao(nomeCategoriaTransacao, "Descrição - " + nomeCategoriaTransacao);

                // Act
                repositorio.Adicionar(categoriaTransacao);

                // Assert
                var metodoPagamentoDoBanco = context.Set<CategoriaTransacao>().FirstOrDefault(m => m.Id == categoriaTransacao.Id);
                metodoPagamentoDoBanco.Should().NotBeNull();
                metodoPagamentoDoBanco.Nome.Should().Be(nomeCategoriaTransacao);
            }
        }

        [Theory(DisplayName = "Adicionar Categoria Transação Inválida - Deve lançar exceção")]
        [InlineData(null)]
        public void Adicionar_CategoriaTransacaoInvalida_DeveLancarExcecao(string nomeCategoriaTransacao)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "Teste_CategoriaTransacao")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var repositorio = new EFCategoriaTransacaoRepositorio(context);
                var categoriaTransacao = new CategoriaTransacao(nomeCategoriaTransacao, "Descrição - " + nomeCategoriaTransacao);

                // Act & Assert
                repositorio.Invoking(r => r.Adicionar(categoriaTransacao)).Should().Throw<Microsoft.EntityFrameworkCore.DbUpdateException>();
            }
        }
    }
}
