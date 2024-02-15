using FluentValidation;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;
using Transacoes.Core.Exceptions;
using Transacoes.Core.Repositories;
using static Transacoes.Core.Services.ITransacaoServico;

namespace Transacoes.Core.Services
{
    public class TransacaoServico : ITransacaoServico
    {
        private readonly ITransacaoRepositorio _repositorio;
        private readonly ISaldoDiaRepositorio _repositorioSaldoDia;

        public TransacaoServico(ITransacaoRepositorio repositorio, ISaldoDiaRepositorio repositorioSaldoDia)
        {
            _repositorio = repositorio;
            _repositorioSaldoDia = repositorioSaldoDia;
        }

        public Transacao Adicionar<TValidator>(Transacao obj) where TValidator : AbstractValidator<Transacao>
        {
            obj.Id = Guid.NewGuid();
            obj.CriadoEm = DateTime.Now;
            obj.CriadoPorId = Guid.NewGuid();
            obj.Excluido = false;

            var validator = new TransacaoValidator();
            var validationResult = validator.Validate(obj);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                throw new TransacoesException(errors);
            }

            _repositorio.Adicionar(obj);

            SaldoDia saldoDia = new SaldoDia()
            {
                Id = Guid.NewGuid(),
                DataSaldo = obj.DataTransacao.Date,
                Saldo = obj.Valor,
            };

            _repositorioSaldoDia.Adicionar(saldoDia);

            return obj;

        }

        [ExcludeFromCodeCoverage(Justification = "Método ainda não foi implementado")]
        public Transacao ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Transacao> ObterTodos()
        {
            return _repositorio.ObterTodos().ToList();
        }

        [ExcludeFromCodeCoverage(Justification = "Método ainda não foi implementado")]
        public void Remover(Transacao obj)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage(Justification = "Método ainda não foi implementado")]
        Transacao IBaseServico<Transacao>.Atualizar<TValidator>(Transacao obj)
        {
            throw new NotImplementedException();
        }
    }
}
