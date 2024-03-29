﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Transacoes.Core.Repositories
{
    public interface IBaseRepositorio<T> where T : class
    {
        IEnumerable<T> ObterTodos();
        IEnumerable<T> Encontrar(Expression<Func<T, bool>> predicate);
        T ObterPorId(Guid id);
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Remover(T entity);
    }
}
