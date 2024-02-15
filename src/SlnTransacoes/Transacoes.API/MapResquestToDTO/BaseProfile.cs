using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using Transacoes.API.Models.Request;
using Transacoes.API.Models.Response;
using Transacoes.Aplicacao.DTOs;

namespace Transacoes.API.MapResquestToDTO
{
    [ExcludeFromCodeCoverage]
    public class BaseProfile: Profile
    {
        public BaseProfile()
        {
            CreateMap<TransacaoRequest, TransacaoDTO>();
            CreateMap<MetodoPagamentoRequest, MetodoPagamentoDTO>();
            CreateMap<MetodoPagamentoDTO, MetodoPagamentoResponse>().ReverseMap();

            CreateMap<CategoriaTransacaoRequest, CategoriaTransacaoDTO>().ReverseMap();
            CreateMap<CategoriaTransacaoDTO, CategoriaTransacaoResponse>().ReverseMap();
        }
    }
}
