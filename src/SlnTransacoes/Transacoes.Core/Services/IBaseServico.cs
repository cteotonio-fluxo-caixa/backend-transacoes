using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;

namespace Transacoes.Core.Services
{
    public interface IBaseServico<T> where T : BaseEntities
    {
        T Adicionar<TValidator>(T obj) where TValidator : AbstractValidator<T>;

        void Remover(T obj);

        IList<T> ObterTodos();

        T ObterPorId(int id);

        T Atualizar<TValidator>(T obj) where TValidator : AbstractValidator<T>;
    }
}
