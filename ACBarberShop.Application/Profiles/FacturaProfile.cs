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
    public class FacturaProfile: Profile
    {
        public FacturaProfile() 
        {
            CreateMap<FacturaDTO, Factura>().ReverseMap();
            CreateMap<FacturaDTO, Factura>()
           .ForMember(dest => dest.IdFactura, orig => orig.MapFrom(o => o.IdFactura))
           .ForMember(dest => dest.IdCliente, orig => orig.MapFrom(o => o.IdCliente))
           .ForMember(dest => dest.Nombre, orig => orig.MapFrom(o => o.Nombre))
           .ForMember(dest => dest.Telefono, orig => orig.MapFrom(o => o.Telefono))
           .ForMember(dest => dest.CorreoElectronico, orig => orig.MapFrom(o => o.CorreoElectronico))
           .ForMember(dest => dest.IdSucursal, orig => orig.MapFrom(o => o.IdSucursal))
           .ForMember(dest => dest.Total, orig => orig.MapFrom(o => o.Total))
           .ForMember(dest => dest.IdEstado, orig => orig.MapFrom(o => o.IdEstado))
           .ForMember(dest => dest.Fecha, orig => orig.MapFrom(o => o.Fecha))
           .ForMember(dest => dest.FacturaProducto, orig => orig.MapFrom(o => o.FacturaProducto))
           .ForMember(dest => dest.FacturaServicio, orig => orig.MapFrom(o => o.FacturaServicio))
           .ForMember(dest => dest.IdClienteNavigation, orig => orig.MapFrom(o => o.IdClienteNavigation))
           .ForMember(dest => dest.IdSucursalNavigation, orig => orig.MapFrom(o => o.IdSucursalNavigation))
           .ForMember(dest => dest.IdEstadoNavigation, orig => orig.MapFrom(o => o.IdEstadoNavigation));
        }
    }
}
