using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Transacoes.Core.Entities;
using Transacoes.Core.Repositories;

namespace Transacoes.Infraestrutura.Repositorios
{
    public class EFSaldoDiaRepositorio : ISaldoDiaRepositorio
    {
        private readonly AppDbContext _dbContext;

        public EFSaldoDiaRepositorio() { }
        public EFSaldoDiaRepositorio(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Adicionar(SaldoDia entity)
        {
            AddOrUpdate(entity);
            _dbContext.SaveChanges();
        }

        public void Atualizar(SaldoDia entity)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage(Justification ="Método não foi implementado")]
        public IEnumerable<SaldoDia> Encontrar(Expression<Func<SaldoDia, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage(Justification = "Método não foi implementado")]
        public SaldoDia ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage(Justification = "Método não foi implementado")]
        public IEnumerable<SaldoDia> ObterTodos()
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage(Justification = "Método não foi implementado")]
        public void Remover(SaldoDia entity)
        {
            throw new NotImplementedException();
        }

        private EntityEntry<SaldoDia> AddOrUpdate(SaldoDia entity)
        {
            var existingEntity = _dbContext.SaldoDiaEntity.FirstOrDefault(e => e.DataSaldo.Date == entity.DataSaldo.Date);

            if (existingEntity != null)
            {
                // Se a entidade já existe, soma o saldo
                existingEntity.Saldo += entity.Saldo;
                return _dbContext.Entry(existingEntity);
            }
            else
            {
                entity.Id = Guid.NewGuid();
                // Se a entidade não existe, adiciona a nova entidade
                return _dbContext.SaldoDiaEntity.Add(entity);
            }
        }
    }
}
