using AutoMapper;
using RotasDeViagem.Application.DTOs;
using RotasDeViagem.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotasDeViagem.Application.Mappings
{
    public class DomainDTOProfile : Profile
    {
        public DomainDTOProfile()
        {
            CreateMap<Voo, VooDTO>().ReverseMap();
            CreateMap<Voo, Voo2DTO>().ReverseMap();
            CreateMap<Escala, EscalaDTO>().ReverseMap();
        }
    }
}
