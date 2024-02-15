using FluentValidation;
using System.Diagnostics.CodeAnalysis;
using Transacoes.Core.Entities;
using Transacoes.Core.Exceptions;
using Transacoes.Core.Repositories;
using static Transacoes.Core.Services.ICategoriaTransacaoServico;

namespace Transacoes.Core.Services
{
    public class CategoriaTransacaoServico : ICategoriaTransacaoServico
    {
        private readonly ICategoriaTransacaoRepositorio _repositorio;

        public CategoriaTransacaoServico(ICategoriaTransacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public CategoriaTransacao Adicionar<TValidator>(CategoriaTransacao obj) where TValidator : AbstractValidator<CategoriaTransacao>
        {
            var validator = new CategoriaTransacaoValidator();
            var validationResult = validator.Validate(obj);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                throw new TransacoesException(errors);
            }

            _repositorio.Adicionar(obj);

            return obj;
        }

        [ExcludeFromCodeCoverage(Justification = "Método ainda não foi implementado")]
        public CategoriaTransacao Atualizar<TValidator>(CategoriaTransacao obj) where TValidator : AbstractValidator<CategoriaTransacao>
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage(Justification = "Método ainda não foi implementado")]
        public CategoriaTransacao ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<CategoriaTransacao> ObterTodos()
        {
            return _repositorio.ObterTodos().ToList();
        }

        [ExcludeFromCodeCoverage(Justification = "Método ainda não foi implementado")]
        public void Remover(CategoriaTransacao obj)
        {
            throw new NotImplementedException();
        }
    }
}
