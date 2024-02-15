using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        [ExcludeFromCodeCoverage(Justification ="Método ainda não foi implementado")]
        public void Atualizar(CategoriaTransacao entity)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage(Justification = "Método ainda não foi implementado")]
        public IEnumerable<CategoriaTransacao> Encontrar(Expression<Func<CategoriaTransacao, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage(Justification = "Método ainda não foi implementado")]
        public CategoriaTransacao ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaTransacao> ObterTodos()
        {
            return _dbContext.Set<CategoriaTransacao>().ToList();
        }

        [ExcludeFromCodeCoverage(Justification = "Método ainda não foi implementado")]
        public void Remover(CategoriaTransacao entity)
        {
            throw new NotImplementedException();
        }
    }
}
