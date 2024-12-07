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
    public class FacturaProductoProfile : Profile
    {
        public FacturaProductoProfile()
        {
            CreateMap<FacturaProductoDTO, FacturaProducto>().ReverseMap();
            CreateMap<FacturaProductoDTO, FacturaProducto>()
            .ForMember(dest => dest.IdFacturaProducto, orig => orig.MapFrom(o => o.IdFacturaProducto))
            .ForMember(dest => dest.IdFactura, orig => orig.MapFrom(o => o.IdFactura))
            .ForMember(dest => dest.IdProducto, orig => orig.MapFrom(o => o.IdProducto))
            .ForMember(dest => dest.Cantidad, orig => orig.MapFrom(o => o.Cantidad))
            .ForMember(dest => dest.SubTotal, orig => orig.MapFrom(o => o.SubTotal))
            .ForMember(dest => dest.IdFacturaNavigation, orig => orig.MapFrom(o => o.IdFacturaNavigation))
            .ForMember(dest => dest.IdProductoNavigation, orig => orig.MapFrom(o => o.IdProductoNavigation));
        }
    }
}
