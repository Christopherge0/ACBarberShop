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
    public class ServicioProfile: Profile
    {
        public ServicioProfile() 
        {
            CreateMap<ServicioDTO, Servicio>().ReverseMap();
            CreateMap<ServicioDTO, Servicio>()
            .ForMember(dest => dest.IdSevicio, orig => orig.MapFrom(o => o.IdSevicio))
            .ForMember(dest => dest.Nombre, orig => orig.MapFrom(o => o.Nombre))
            .ForMember(dest => dest.Descripcion, orig => orig.MapFrom(o => o.Descripcion))
            .ForMember(dest => dest.Tarifa, orig => orig.MapFrom(o => o.Tarifa))
            .ForMember(dest => dest.TiempoServicio, orig => orig.MapFrom(o => o.TiempoServicio))
            .ForMember(dest => dest.IdProducto, orig => orig.MapFrom(o => o.IdProducto))
            .ForMember(dest => dest.AreaEnfoque, orig => orig.MapFrom(o => o.AreaEnfoque))
            .ForMember(dest => dest.Cita, orig => orig.MapFrom(o => o.Cita))
            .ForMember(dest => dest.FacturaServicio, orig => orig.MapFrom(o => o.FacturaServicio));
        }
    }
}
