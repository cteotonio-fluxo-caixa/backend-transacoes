using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;
using Transacoes.Core.Repositories;

namespace Transacoes.Core.Services
{
    //public class BaseServico<T> : IBaseServico<T> where T : BaseEntities
    //{
    //    private readonly IRepositorio<T> _repositorio;
    //    public BaseServico(IRepositorio<T> repositorio)
    //    {
    //        _repositorio = repositorio;
    //    }

    //    public T Adicionar<TValidator>(T obj) where TValidator : AbstractValidator<T>
    //    {
    //        _repositorio.Adicionar(obj);
    //        return obj;
    //    }

    //    public T Atualizar<TValidator>(T obj) where TValidator : AbstractValidator<T>
    //    {
    //        _repositorio.Atualizar(obj);
    //        return obj;
    //    }

    //    public T ObterPorId(int id)
    //    {
    //        return _repositorio.ObterPorId(id);
    //    }

    //    public IList<T> ObterTodos()
    //    {
    //        return _repositorio.ObterTodos().ToList();
    //    }

    //    public void Remover(T obj)
    //    {
    //        _repositorio.Remover(obj);

    //    }

    //}
}
