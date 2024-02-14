using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Aplicacao.DTOs;
using Transacoes.Core.Entities;

namespace Transacoes.Aplicacao.Servicos
{
    public interface ICategoriaTransacaoAppService
    {
        Task<CategoriaTransacaoDTO> RegistrarCategoriaTransacao(CategoriaTransacaoDTO categoriaTransacaoDTO);
        Task<List<CategoriaTransacaoDTO>> LitsarTodosMetodosPagamentos();
    }
}
