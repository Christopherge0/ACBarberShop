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
    public class DireccionProfile: Profile
    {
        public DireccionProfile() 
        {
            CreateMap<DireccionDTO, Direccion>().ReverseMap();
            CreateMap<DireccionDTO, Direccion>()
            .ForMember(dest => dest.IdDireccion, orig => orig.MapFrom(o => o.IdDireccion))
            .ForMember(dest => dest.Provincia, orig => orig.MapFrom(o => o.Provincia))
            .ForMember(dest => dest.Canton, orig => orig.MapFrom(o => o.Canton))
            .ForMember(dest => dest.Distrito, orig => orig.MapFrom(o => o.Distrito))
            .ForMember(dest => dest.DireccionExacta, orig => orig.MapFrom(o => o.DireccionExacta))
            .ForMember(dest => dest.Sucursal, orig => orig.MapFrom(o => o.Sucursal))
            .ForMember(dest => dest.Usuario, orig => orig.MapFrom(o => o.Usuario));
        }
    }
}
