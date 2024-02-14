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
    public class EFMetodoPagamentoRepositorio : IMetodoPagamentoRepositorio
    {
        private readonly AppDbContext _dbContext;

        public EFMetodoPagamentoRepositorio(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Adicionar(MetodoPagamento entity)
        {
            _dbContext.Set<MetodoPagamento>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Atualizar(MetodoPagamento entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MetodoPagamento> Encontrar(Expression<Func<MetodoPagamento, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public MetodoPagamento ObterPorId(Guid id)
        {
            return _dbContext.Set<MetodoPagamento>().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<MetodoPagamento> ObterTodos()
        {
            return _dbContext.Set<MetodoPagamento>().ToList();
        }

        public void Remover(MetodoPagamento entity)
        {
            throw new NotImplementedException();
        }
    }
}
