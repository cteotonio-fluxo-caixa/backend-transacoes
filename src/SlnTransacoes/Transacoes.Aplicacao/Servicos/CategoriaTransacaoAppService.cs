using AutoMapper;
using Transacoes.Aplicacao.DTOs;
using Transacoes.Core.Entities;
using Transacoes.Core.Services;
using static Transacoes.Core.Services.ICategoriaTransacaoServico;

namespace Transacoes.Aplicacao.Servicos
{
    public class CategoriaTransacaoAppService : ICategoriaTransacaoAppService
    {
        private readonly ICategoriaTransacaoServico _categoriatransacaoServico;
        private readonly IMapper _mapper;

        public CategoriaTransacaoAppService(ICategoriaTransacaoServico categoriatransacaoServico, IMapper mapper)
        {
            _categoriatransacaoServico = categoriatransacaoServico;
            _mapper = mapper;
        }

        public async Task<List<CategoriaTransacaoDTO>> LitsarTodasCategoriasTransacao()
        {
            var listacategoriaTransacao = _categoriatransacaoServico.ObterTodos();
            if (listacategoriaTransacao != null)
                return _mapper.Map<List<CategoriaTransacaoDTO>>(listacategoriaTransacao);
            else
                return null;
        }

        public async Task<CategoriaTransacaoDTO> RegistrarCategoriaTransacao(CategoriaTransacaoDTO categoriaTransacaoDTO)
        {
            var categoriatransacao = _mapper.Map<CategoriaTransacao>(categoriaTransacaoDTO);
            var categoriaTransacaoAdicionado = _categoriatransacaoServico.Adicionar<CategoriaTransacaoValidator>(categoriatransacao);
            return _mapper.Map<CategoriaTransacaoDTO>(categoriaTransacaoAdicionado);
        }
    }
}
