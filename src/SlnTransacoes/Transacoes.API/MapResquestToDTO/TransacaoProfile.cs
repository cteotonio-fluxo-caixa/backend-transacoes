using AutoMapper;
using Transacoes.API.Models.Request;
using Transacoes.Aplicacao.DTOs;

namespace Transacoes.API.MapResquestToDTO
{
    public class TransacaoProfile: Profile
    {
        public TransacaoProfile()
        {
            CreateMap<TransacaoRequest, TransacaoDTO>();
                //.ForMember(
                //    dest => dest.TipoTransacao,
                //    opt => opt.MapFrom(scr => (scr.Valor < 0.0m) ? Tipo.Debito : Tipo.Credito)
                //    );
        }
    }
}
