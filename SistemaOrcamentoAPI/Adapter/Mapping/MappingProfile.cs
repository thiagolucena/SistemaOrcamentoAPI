using ApplicationDTO.DTO;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Item, ItemDTO>().ReverseMap();
            CreateMap<Orcamento, OrcamentoDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<ItemOrcamento, ItemOrcamentoDTO>().ReverseMap();
        }
    }
}
