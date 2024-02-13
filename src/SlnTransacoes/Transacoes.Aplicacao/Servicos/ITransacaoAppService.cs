using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Aplicacao.DTOs;
using Transacoes.Core.Repositories;

namespace Transacoes.Aplicacao.Servicos
{
    public interface ITransacaoAppService
    {
        Task<TransacaoDTO> RegistrarTransacao(TransacaoDTO transacao);
        Task<List<TransacaoDTO>> ConsultaTransacaoPorData(DateTime Data);
    }
}
