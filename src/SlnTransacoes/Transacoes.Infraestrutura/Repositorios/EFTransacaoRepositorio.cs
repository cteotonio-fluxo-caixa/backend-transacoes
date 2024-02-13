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
    public class EFTransacaoRepository : ITransacaoRepositorio
    {
        private readonly AppDbContext _dbContext;

        public EFTransacaoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Transacao ObterPorId(Guid id)
        {
            return null; //_dbContext.Set<Transacao>().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Transacao> ObterTodos()
        {
            return _dbContext.Set<Transacao>().ToList();
        }

        public void Adicionar(Transacao transacao)
        {
            try { 
            _dbContext.Set<Transacao>().Add(transacao);
            _dbContext.SaveChanges();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public IEnumerable<Transacao> ObterPorData(DateTime Data)
        {
            return null;
            //var lista = _dbContext.TransacaoEntity.Where(w => w.Data.HasValue && w.Data.Value.Date == Data.Date).Select(s =>
            //    new Transacao
            //    {
            //        Id = s.Id,
            //        //CategoriaId = s.CategoriaId,
            //        Data = s.Data,
            //        //TipoTransacao = s.TipoTransacao,
            //        Valor = s.Valor
            //    }
            //    );
            //return lista;
        }

        public IEnumerable<Transacao> Encontrar(Expression<Func<Transacao, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Transacao ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Transacao entity)
        {
            throw new NotImplementedException();
        }

        public void Remover(Transacao entity)
        {
            throw new NotImplementedException();
        }
    }
}
