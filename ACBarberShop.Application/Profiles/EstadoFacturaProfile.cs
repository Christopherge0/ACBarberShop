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
    public class EstadoFacturaProfile: Profile
    {
        public EstadoFacturaProfile() 
        {
            CreateMap<EstadoFacturaDTO, EstadoFactura>().ReverseMap();
            CreateMap<EstadoFacturaDTO, EstadoFactura>()
           .ForMember(dest => dest.IdEstadoFactura, orig => orig.MapFrom(o => o.IdEstadoFactura))
           .ForMember(dest => dest.Descripccion, orig => orig.MapFrom(o => o.Descripccion))
           .ForMember(dest => dest.Factura, orig => orig.MapFrom(o => o.Factura));
        }
    }
}
