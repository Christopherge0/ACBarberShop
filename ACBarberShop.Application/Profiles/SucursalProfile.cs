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
    public class SucursalProfile: Profile
    {
        public SucursalProfile() 
        {
            CreateMap<SucursalDTO, Sucursal>().ReverseMap();
            CreateMap<SucursalDTO, Sucursal>()
           .ForMember(dest => dest.IdSucursal, orig => orig.MapFrom(o => o.IdSucursal))
           .ForMember(dest => dest.Nombre, orig => orig.MapFrom(o => o.Nombre))
           .ForMember(dest => dest.Descripcion, orig => orig.MapFrom(o => o.Descripcion))
           .ForMember(dest => dest.Telefono, orig => orig.MapFrom(o => o.Telefono))
           .ForMember(dest => dest.IdDireccion, orig => orig.MapFrom(o => o.IdDireccion))
           .ForMember(dest => dest.CorreoElectronico, orig => orig.MapFrom(o => o.CorreoElectronico))
           .ForMember(dest => dest.Cita, orig => orig.MapFrom(o => o.Cita))
           .ForMember(dest => dest.Factura, orig => orig.MapFrom(o => o.Factura))
           .ForMember(dest => dest.Horario, orig => orig.MapFrom(o => o.Horario))
           .ForMember(dest => dest.IdDireccionNavigation, orig => orig.MapFrom(o => o.IdDireccionNavigation));
        }
    }
}
