using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;
using Transacoes.Core.Exceptions;
using Transacoes.Core.Repositories;
using static Transacoes.Core.Services.IMetodoPagamentoServico;
using static Transacoes.Core.Services.ITransacaoServico;

namespace Transacoes.Core.Services
{
    public class MetodoPagamentoServico : IMetodoPagamentoServico
    {
        private readonly IMetodoPagamentoRepositorio _repositorio;

        public MetodoPagamentoServico(IMetodoPagamentoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public MetodoPagamento Adicionar<TValidator>(MetodoPagamento obj) where TValidator : AbstractValidator<MetodoPagamento>
        {
            var validator = new MetodoPagamentoValidator();
            var validationResult = validator.Validate(obj);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                throw new TransacoesException(errors);
            }

            _repositorio.Adicionar(obj);

            return obj;
        }

        public MetodoPagamento Atualizar<TValidator>(MetodoPagamento obj) where TValidator : AbstractValidator<MetodoPagamento>
        {
            throw new NotImplementedException();
        }

        public MetodoPagamento ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<MetodoPagamento> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(MetodoPagamento obj)
        {
            throw new NotImplementedException();
        }
    }
}
