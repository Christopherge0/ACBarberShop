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
    public class RolProfile: Profile
    {
        public RolProfile() 
        {
            CreateMap<RolDTO, Rol>().ReverseMap();
            CreateMap<RolDTO, Rol>()
           .ForMember(dest => dest.IdRol, orig => orig.MapFrom(o => o.IdRol))
           .ForMember(dest => dest.Descripcion, orig => orig.MapFrom(o => o.Descripcion))
           .ForMember(dest => dest.Usuario, orig => orig.MapFrom(o => o.Usuario));
        }
    }
}
