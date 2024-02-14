using Moq;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;
using Transacoes.Core.Exceptions;
using Transacoes.Core.Repositories;
using Transacoes.Core.Services;
using Transacoes.Testes.Domain.Builders;
using Transacoes.Testes.Services.Builders;
using static Transacoes.Core.Services.IMetodoPagamentoServico;
using static Transacoes.Core.Services.ITransacaoServico;

namespace Transacoes.Testes.Domain
{
    public class MetodoPagamentoServicoTeste
    {
        [Theory(DisplayName = "Adicionar Método de Pagamento Válido - Deve Adicionar")]
        [InlineData("Cenário 1: ", "PIX", "Pagamento via PIX")]
        [InlineData("Cenário 2: ", "Crédito", "Pagamento via Cartão de Crédito")]
        public void Adicionar_MetodoPagamentoValido_DeveAdicionar(string cenario, string nome, string descricao)
        {
            var metodopagamento = new MetodoPagamentoBuilder().Build();

            metodopagamento.Nome = nome;
            metodopagamento.Descricao = descricao;

            var mockRepositorio = new Mock<IMetodoPagamentoRepositorio>();
            var servico = new MetodoPagamentoServico(mockRepositorio.Object);

            // Assert
            var obj = servico.Adicionar<MetodoPagamentoValidator>(metodopagamento);
            Assert.NotNull(obj);

        }

        [Theory(DisplayName = "Adicionar Método de Pagamento Inválido - Deve lança exceção")]
        [InlineData("Cenário 1: Um nome deve ser informado ", null, "Pagamento via PIX")]
        [InlineData("Cenário 2: O nome precisa ter no mínimo 2 caracteres ", "A", "Pagamento via PIX")]
        [InlineData("Cenário 3: O nome precisa ter no máximo 20 caracteres ", "Nome Mais de Vinte Caracteres", "Pagamento via PIX")]
        [InlineData("Cenário 4: Uma descrição deve ser informada ", "Crédito", null)]
        [InlineData("Cenário 5: A descrição precisa ter no mínimo 10 caracteres ", "Crédito", "menos 10")]
        [InlineData("Cenário 6: A descrição precisa ter no máximo 50 caracteres ", "Crédito", "Descrição com mais de 50 caracteres, hjdghsadadgjasdgda")]
        public void Adicionar_MetodoPagamentoInvalido_DeveLancarExcecao(string cenarioteste, string nome, string descricao)
        {
            var metodopagamento = new MetodoPagamentoBuilder().Build();

            metodopagamento.Nome = nome;
            metodopagamento.Descricao = descricao;

            var mockRepositorio = new Mock<IMetodoPagamentoRepositorio>();
            var servico = new MetodoPagamentoServico(mockRepositorio.Object);

            // Assert
            var ex = Assert.Throws<TransacoesException>(() => servico.Adicionar<MetodoPagamentoValidator>(metodopagamento));
            Assert.Contains(ex.GetErrorMessage(), cenarioteste);

        }
    }
}
