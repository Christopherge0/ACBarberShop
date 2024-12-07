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
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CategoriaDTO, Categoria>().ReverseMap();
            CreateMap<CategoriaDTO, CategoriaDTO>()
                .ForMember(dest => dest.IdCategoria, orig => orig.MapFrom(o => o.IdCategoria))
                .ForMember(dest => dest.Nombre, orig => orig.MapFrom(o => o.Nombre))
                .ForMember(dest => dest.Producto, orig => orig.MapFrom(o => o.Producto));
        }
    }
}
