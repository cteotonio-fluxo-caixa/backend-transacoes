using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Aplicacao.DTOs;

namespace Transacoes.Aplicacao.Servicos
{
    public interface IMetodoPagamentoAppService
    {
        Task<MetodoPagamentoDTO> RegistrarMetodoPagamento(MetodoPagamentoDTO metodoPagamentoDTO);
        Task<List<MetodoPagamentoDTO>> LitsarTodosMetodosPagamentos();
    }
}
