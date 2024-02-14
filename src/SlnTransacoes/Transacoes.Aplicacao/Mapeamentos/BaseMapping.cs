using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacoes.Aplicacao.DTOs;
using Transacoes.Core.Entities;

namespace Transacoes.Aplicacao.Mapeamentos
{
    
    public class MappingProfile<T, TDto> : Profile
    where T : BaseEntities
    where TDto : BaseDto
    {
        public MappingProfile()
        {
            CreateMap<T, TDto>().ReverseMap();
        }
    }

    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            // Registrar todos os tipos de entidades e DTOs que serão usados em sua aplicação
            CreateMap<Transacao, TransacaoDTO>().ReverseMap();
            CreateMap<MetodoPagamento, MetodoPagamentoDTO>().ReverseMap();
            CreateMap<CategoriaTransacao, CategoriaTransacaoDTO>().ReverseMap();
            // Adicione outros mapeamentos aqui, se necessário
        }
    }

    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceMappingProfile());
            });

            return config.CreateMapper();
        }
    }
}
