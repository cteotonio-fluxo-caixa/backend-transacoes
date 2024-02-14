using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;

namespace Transacoes.Testes.Domain.Builders
{
    public class MetodoPagamentoBuilder
    {
        public MetodoPagamento Build() 
        {
            return new MetodoPagamento()
            {
                Id = Guid.NewGuid(),
                Nome = "Nome Padrão",
                Descricao = "Descrição Padrão"
            };
        }
    }
}
