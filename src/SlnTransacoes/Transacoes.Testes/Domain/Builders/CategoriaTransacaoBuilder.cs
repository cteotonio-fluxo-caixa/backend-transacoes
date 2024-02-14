using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;

namespace Transacoes.Testes.Domain.Builders
{
    public class CategoriaTransacaoBuilder
    {
        public CategoriaTransacao Build()
        {
            return new CategoriaTransacao()
            {
                Id = Guid.NewGuid(),
                Nome = "Categoria",
                Descricao = "Descrição categoria"
            };
        }
    }
}
