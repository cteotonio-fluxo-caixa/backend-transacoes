using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;
using Transacoes.Core.Repositories;

namespace Transacoes.Infraestrutura.Repositorios
{
    public class EFCategoriaTransacaoRepositorio : ICategoriaTransacaoRepositorio
    {
        private readonly AppDbContext _dbContext;

        public EFCategoriaTransacaoRepositorio(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Adicionar(CategoriaTransacao entity)
        {
            _dbContext.Set<CategoriaTransacao>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Atualizar(CategoriaTransacao entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaTransacao> Encontrar(Expression<Func<CategoriaTransacao, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public CategoriaTransacao ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaTransacao> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(CategoriaTransacao entity)
        {
            throw new NotImplementedException();
        }
    }
}
