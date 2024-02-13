using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Core.Entities;

namespace Transacoes.Testes.Services.Builders
{
    public class TransacaoBuilder
    {
        public Transacao Build()
        {
            return new Transacao()
            {
                CategoriaId = Guid.NewGuid(),
                CriadoEm = DateTime.Now,
                CriadoPorId = Guid.NewGuid(),
                DataTransacao = DateTime.Now,
                Descricao = "Descrição padrão",
                Excluido = false,
                ExcluidoEm = null,
                ExcluidoPor = null,
                Id = Guid.NewGuid(),
                IsCredito = false,
                MetodoPagamentoId = Guid.NewGuid(),
                ModificadoEm = null,
                ModificadoPor = null,
                Valor = 0
            };
        }
    }
}
