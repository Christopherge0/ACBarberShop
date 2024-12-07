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
    public  class UsuarioProfile: Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
            CreateMap<UsuarioDTO, Usuario>()
            .ForMember(dest => dest.IdUsuario, orig => orig.MapFrom(o => o.IdUsuario))
            .ForMember(dest => dest.Nombre, orig => orig.MapFrom(o => o.Nombre))
            .ForMember(dest => dest.Telefono, orig => orig.MapFrom(o => o.Telefono))
            .ForMember(dest => dest.CorreoElectronico, orig => orig.MapFrom(o => o.CorreoElectronico))
            .ForMember(dest => dest.IdDireccion, orig => orig.MapFrom(o => o.IdDireccion))
            .ForMember(dest => dest.FechaNacimiento, orig => orig.MapFrom(o => o.FechaNacimiento))
            .ForMember(dest => dest.Contrasenia, orig => orig.MapFrom(o => o.Contrasenia))
            .ForMember(dest => dest.IdRol, orig => orig.MapFrom(o => o.IdRol))
            .ForMember(dest => dest.IdSucursal, orig => orig.MapFrom(o => o.IdSucursal))
            .ForMember(dest => dest.Cita, orig => orig.MapFrom(o => o.Cita))
            .ForMember(dest => dest.Factura, orig => orig.MapFrom(o => o.Factura))
            .ForMember(dest => dest.IdDireccionNavigation, orig => orig.MapFrom(o => o.IdDireccionNavigation))
            .ForMember(dest => dest.IdRolNavigation, orig => orig.MapFrom(o => o.IdRolNavigation))
            .ForMember(dest => dest.IdSucursalNavigation, orig => orig.MapFrom(o => o.IdSucursalNavigation));


        }
    }
}
