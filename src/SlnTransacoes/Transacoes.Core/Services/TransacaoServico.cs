using FluentValidation;
using System;
using System.Collections.Generic;
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

        public TransacaoServico(ITransacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Transacao Adicionar<TValidator>(Transacao obj) where TValidator : AbstractValidator<Transacao>
        {
            //Validate(obj, Activator.CreateInstance<TValidator>());
            var validator = new TransacaoValidator();
            var validationResult = validator.Validate(obj);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                throw new TransacoesException(errors);
            }

            _repositorio.Adicionar(obj);

            return obj;

        }

        private void Validate<TValidator>(Transacao obj, TValidator validator) where TValidator : AbstractValidator<Transacao>
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }

        public Transacao ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Transacao> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Transacao obj)
        {
            throw new NotImplementedException();
        }

        Transacao IBaseServico<Transacao>.Atualizar<TValidator>(Transacao obj)
        {
            throw new NotImplementedException();
        }
    }
}
