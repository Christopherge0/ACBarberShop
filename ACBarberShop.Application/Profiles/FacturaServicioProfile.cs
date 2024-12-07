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
    public class FacturaServicioProfile: Profile
    {
        public FacturaServicioProfile() 
        {
            CreateMap<FacturaServicioDTO, FacturaServicio>().ReverseMap();
            CreateMap<FacturaServicioDTO, FacturaServicio>()
            .ForMember(dest => dest.IdFacturaServicio, orig => orig.MapFrom(o => o.IdFacturaServicio))
            .ForMember(dest => dest.IdFactura, orig => orig.MapFrom(o => o.IdFactura))
            .ForMember(dest => dest.IdServicio, orig => orig.MapFrom(o => o.IdServicio))
            .ForMember(dest => dest.SubTotal, orig => orig.MapFrom(o => o.SubTotal))
            .ForMember(dest => dest.Cantidad, orig => orig.MapFrom(o => o.Cantidad))
            .ForMember(dest => dest.IdFacturaNavigation, orig => orig.MapFrom(o => o.IdFacturaNavigation));

        }
    }
}
