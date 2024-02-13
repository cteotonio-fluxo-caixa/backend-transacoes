using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using static Transacoes.Core.Services.ITransacaoServico;
using Transacoes.Core.Entities;
using Transacoes.Core.Repositories;
using Transacoes.Core.Services;
using Transacoes.Testes.Services.Builders;
using Transacoes.Core.Exceptions;

namespace Transacoes.Testes.Domain
{

    public partial class TransacaoServiceTeste
    {

        [Theory(DisplayName ="Adicionar Transação Válida - Deve Adicionar")]
        [MemberData(nameof(TransacoesValidas))]
        public void Adicionar_TransacaoValida_DeveAdicionar(string NomeTeste, Guid Id, decimal Valor, DateTime DataTransacao,
                                                            bool IsCredito, string Descricao, Guid CriadoPorId, DateTime CriadoEm, 
                                                            Guid CategoriaId, Guid MetodoPagamentoId)
        {
            var transacao = new TransacaoBuilder().Build();

            transacao.Id = Id;
            transacao.Valor = Valor;
            transacao.DataTransacao = DataTransacao;
            transacao.IsCredito = IsCredito;
            transacao.Descricao = Descricao;
            transacao.CriadoPorId = CriadoPorId;
            transacao.CriadoEm = CriadoEm;
            transacao.CategoriaId = CategoriaId;
            transacao.MetodoPagamentoId = MetodoPagamentoId;

            var mockRepositorio = new Mock<ITransacaoRepositorio>();
            var servico = new TransacaoServico(mockRepositorio.Object);

            // Assert
            mockRepositorio.Verify(r => r.Adicionar(transacao), Times.Once);

        }

        [Theory(DisplayName = "Adicionar Transação Inválida deve lançar exceção")]
        [MemberData(nameof(TransacoesInValidas))]
        public void Adicionar_TransacaoInvalidaValida_DeveLancarExececao(string CenarioTeste, Guid Id, decimal Valor, DateTime DataTransacao,
                                                            bool IsCredito, string Descricao, Guid CriadoPorId, DateTime CriadoEm,
                                                            Guid CategoriaId, Guid MetodoPagamentoId)
        {
            var transacao = new TransacaoBuilder().Build();

            transacao.Id = Id;
            transacao.Valor = Valor;
            transacao.DataTransacao = DataTransacao;
            transacao.IsCredito = IsCredito;
            transacao.Descricao = Descricao;
            transacao.CriadoPorId = CriadoPorId;
            transacao.CriadoEm = CriadoEm;
            transacao.CategoriaId = CategoriaId;
            transacao.MetodoPagamentoId = MetodoPagamentoId;

            var mockRepositorio = new Mock<ITransacaoRepositorio>();
            var servico = new TransacaoServico(mockRepositorio.Object);

            // Assert
            var ex = Assert.Throws<TransacoesException>(() => servico.Atualizar<TransacaoValidator>(transacao));
            Assert.Contains( ex.GetErrorMessage(), CenarioTeste);
        }

    }
}
