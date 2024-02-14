using Moq;
using Transacoes.Core.Exceptions;
using Transacoes.Core.Repositories;
using Transacoes.Core.Services;
using Transacoes.Infraestrutura.Repositorios;
using Transacoes.Testes.Domain.Builders;
using static Transacoes.Core.Services.ICategoriaTransacaoServico;

namespace Transacoes.Testes.Domain
{
    public class CategoriaTransacaoServicoTeste
    {
        [Theory(DisplayName = "Adicionar Categoria Transacao Válida - Deve Adicionar")]
        [InlineData("Cenário 1: ", "Alimentação", "Despesas com alimentação")]
        [InlineData("Cenário 2: ", "Recebimentos", "Recebimentos de valores")]
        public void Adicionar_CategoriaTransacaoValida_DeveAdicionar(string cenario, string nome, string descricao)
        {
            var CategoriaTransacao = new CategoriaTransacaoBuilder().Build();

            CategoriaTransacao.Nome = nome;
            CategoriaTransacao.Descricao = descricao;

            var mockRepositorio = new Mock<ICategoriaTransacaoRepositorio>();
            var servico = new CategoriaTransacaoServico(mockRepositorio.Object);

            // Assert
            var obj = servico.Adicionar<CategoriaTransacaoValidator>(CategoriaTransacao);
            Assert.NotNull(obj);

        }

        [Theory(DisplayName = "Adicionar Categoria Transacao Inválida - Deve lança exceção")]
        [InlineData("Cenário 1: Um nome deve ser informado ", null, "Pagamento via PIX")]
        [InlineData("Cenário 2: O nome precisa ter no mínimo 2 caracteres ", "A", "Pagamento via PIX")]
        [InlineData("Cenário 3: O nome precisa ter no máximo 20 caracteres ", "Nome Mais de Vinte Caracteres", "Pagamento via PIX")]
        [InlineData("Cenário 4: Uma descrição deve ser informada ", "Crédito", null)]
        [InlineData("Cenário 5: A descrição precisa ter no mínimo 10 caracteres ", "Crédito", "menos 10")]
        [InlineData("Cenário 6: A descrição precisa ter no máximo 50 caracteres ", "Crédito", "Descrição com mais de 50 caracteres, hjdghsadadgjasdgda")]
        public void Adicionar_CategoriaTransacaoInvalida_DeveLancarExcecao(string cenarioteste, string nome, string descricao)
        {
            var CategoriaTransacao = new CategoriaTransacaoBuilder().Build();

            CategoriaTransacao.Nome = nome;
            CategoriaTransacao.Descricao = descricao;

            var mockRepositorio = new Mock<ICategoriaTransacaoRepositorio>();
            var servico = new CategoriaTransacaoServico(mockRepositorio.Object);

            // Assert
            var ex = Assert.Throws<TransacoesException>(() => servico.Adicionar<CategoriaTransacaoValidator>(CategoriaTransacao));
            Assert.Contains(ex.GetErrorMessage(), cenarioteste);

        }
    }
}
