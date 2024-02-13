using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Aplicacao.DTOs;
using Transacoes.Core.Entities;
using Transacoes.Core.Services;
using static Transacoes.Core.Services.ITransacaoServico;

namespace Transacoes.Aplicacao.Servicos
{
    public class TransacaoAppService: ITransacaoAppService
    {
        private readonly ITransacaoServico _transacaoServico;
        private readonly IMapper _mapper;

        public TransacaoAppService(ITransacaoServico transacaoServico, IMapper mapper)
        {
            _transacaoServico = transacaoServico;
            _mapper = mapper;
        }

        public async Task<TransacaoDTO> RegistrarTransacao(TransacaoDTO obj)
        {
            var transacao = _mapper.Map<Transacao>(obj);
            var transacaoAdicionada = _transacaoServico.Adicionar<TransacaoValidator>(transacao);
            return _mapper.Map<TransacaoDTO>(transacaoAdicionada);
        }

        public async Task<List<TransacaoDTO>> ConsultaTransacaoPorData(DateTime Data)
        {
            throw new NotImplementedException();
        }

        #region Verificar
        public TransacaoDTO Adicionar(TransacaoDTO obj)
        {
            var transacao = _mapper.Map<Transacao>(obj);
            var transacaoAdicionada = _transacaoServico.Adicionar<TransacaoValidator>(transacao);
            return _mapper.Map<TransacaoDTO>(transacaoAdicionada);
        }

        public void Remover(TransacaoDTO obj)
        {
            var transacao = _mapper.Map<Transacao>(obj);
            _transacaoServico.Remover(transacao);
        }

        public IList<TransacaoDTO> ObterTodos()
        {
            var transacoes = _transacaoServico.ObterTodos();
            return _mapper.Map<List<TransacaoDTO>>(transacoes);
        }

        public TransacaoDTO ObterPorId(int id)
        {
            var transacao = _transacaoServico.ObterPorId(id);
            return _mapper.Map<TransacaoDTO>(transacao);
        }

        public TransacaoDTO Atualizar(TransacaoDTO obj)
        {
            var transacao = _mapper.Map<Transacao>(obj);
            var transacaoAtualizada = _transacaoServico.Atualizar<TransacaoValidator>(transacao);
            return _mapper.Map<TransacaoDTO>(transacaoAtualizada);
        }
        # endregion Verificar
    }
}

