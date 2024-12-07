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
    public class HorarioProfile: Profile
    {
        public HorarioProfile() 
        {
            CreateMap<HorarioDTO, Horario>().ReverseMap();
            CreateMap<HorarioDTO, Horario>()
            .ForMember(dest => dest.IdHorario, orig => orig.MapFrom(o => o.IdHorario))
            .ForMember(dest => dest.IdSucursal, orig => orig.MapFrom(o => o.IdSucursal))
            .ForMember(dest => dest.DiaSemana, orig => orig.MapFrom(o => o.DiaSemana))
            .ForMember(dest => dest.HoraInicio, orig => orig.MapFrom(o => o.HoraInicio))
            .ForMember(dest => dest.HoraFin, orig => orig.MapFrom(o => o.HoraFin))
            .ForMember(dest => dest.FechaInicio, orig => orig.MapFrom(o => o.FechaInicio))
            .ForMember(dest => dest.FechaFin, orig => orig.MapFrom(o => o.FechaFin))
            .ForMember(dest => dest.IdEstado, orig => orig.MapFrom(o => o.IdEstado))
            .ForMember(dest => dest.IdEstadoNavigation, orig => orig.MapFrom(o => o.IdEstadoNavigation))
            .ForMember(dest => dest.IdSucursalNavigation, orig => orig.MapFrom(o => o.IdSucursalNavigation));
        }
    }
}
