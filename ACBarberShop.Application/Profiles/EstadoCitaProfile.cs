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
    public class EstadoCitaProfile: Profile
    {
        public EstadoCitaProfile()
        {
            CreateMap<EstadosCitaDTO, EstadosCita>().ReverseMap();
            CreateMap<EstadosCitaDTO, EstadosCita>()
            .ForMember(dest => dest.IdEstadoCita, orig => orig.MapFrom(o => o.IdEstadoCita))
            .ForMember(dest => dest.Estado, orig => orig.MapFrom(o => o.Estado))
            .ForMember(dest => dest.Cita, orig => orig.MapFrom(o => o.Cita));
        }
    }
}
