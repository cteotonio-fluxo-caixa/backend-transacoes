using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Aplicacao.DTOs;
using Transacoes.Core.Entities;
using Transacoes.Core.Services;
using static Transacoes.Core.Services.IMetodoPagamentoServico;
using static Transacoes.Core.Services.ITransacaoServico;

namespace Transacoes.Aplicacao.Servicos
{
    public class MetodoPagamentoAppService : IMetodoPagamentoAppService
    {
        private readonly IMetodoPagamentoServico _metodopagamentoServico;
        private readonly IMapper _mapper;

        public MetodoPagamentoAppService(IMetodoPagamentoServico metodopagamentoServico, IMapper mapper)
        {
            _metodopagamentoServico = metodopagamentoServico;
            _mapper = mapper;
        }

        public async Task<List<MetodoPagamentoDTO>> LitsarTodosMetodosPagamentos()
        {
            throw new NotImplementedException();
        }

        public async Task<MetodoPagamentoDTO> RegistrarMetodoPagamento(MetodoPagamentoDTO metodoPagamentoDTO)
        {
            var metodopagamento = _mapper.Map<MetodoPagamento>(metodoPagamentoDTO);
            var metodopagamentoAdicionado = _metodopagamentoServico.Adicionar<MetodoPagamentoValidator>(metodopagamento);
            return _mapper.Map<MetodoPagamentoDTO>(metodopagamentoAdicionado);
            
        }
    }
}
