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
    public class CitaProfile : Profile
    {
        public CitaProfile() 
        {
            CreateMap<CitaDTO, Cita>().ReverseMap();
            CreateMap<CitaDTO, Cita>()
            .ForMember(dest => dest.IdCita, orig => orig.MapFrom(o => o.IdCita))
            .ForMember(dest => dest.IdCliente, orig => orig.MapFrom(o => o.IdCliente))
            .ForMember(dest => dest.IdSucursal, orig => orig.MapFrom(o => o.IdSucursal))
            .ForMember(dest => dest.IdServicio, orig => orig.MapFrom(o => o.IdServicio))
            .ForMember(dest => dest.IdEstado, orig => orig.MapFrom(o => o.IdEstado))
            .ForMember(dest => dest.FechaHora, orig => orig.MapFrom(o => o.FechaHora))
            .ForMember(dest => dest.FechaHoraReprogramada, orig => orig.MapFrom(o => o.FechaHoraReprogramada))
            .ForMember(dest => dest.FechaCreacion, orig => orig.MapFrom(o => o.FechaCreacion))
            .ForMember(dest => dest.IdClienteNavigation, orig => orig.MapFrom(o => o.IdClienteNavigation))
            .ForMember(dest => dest.IdEstadoNavigation, orig => orig.MapFrom(o => o.IdEstadoNavigation))
            .ForMember(dest => dest.IdServicioNavigation, orig => orig.MapFrom(o => o.IdServicioNavigation))
            .ForMember(dest => dest.IdSucursalNavigation, orig => orig.MapFrom(o => o.IdSucursalNavigation));
        }
    }
}
