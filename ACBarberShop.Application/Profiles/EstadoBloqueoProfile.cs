using ACBarberShop.Application.DTOs;
using ACBarberShop.Infraestructure.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.Profiles
{
    public class EstadoBloqueoProfile: Profile
    {
        public EstadoBloqueoProfile()
        {
            CreateMap<EstadoBloqueoDTO, EstadoBloqueo>().ReverseMap();
            CreateMap<EstadoBloqueoDTO, EstadoBloqueo>()
            .ForMember(dest => dest.IdEstadBlokeo, orig => orig.MapFrom(o => o.IdEstadBlokeo))
            .ForMember(dest => dest.Estado, orig => orig.MapFrom(o => o.Estado))
            .ForMember(dest => dest.Horario, orig => orig.MapFrom(o => o.Horario));
        }

    }
}
