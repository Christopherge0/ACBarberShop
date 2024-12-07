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
    public class ProductoProfile: Profile
    {
        public ProductoProfile() 
        {
            CreateMap<ProductoDTO, Producto>().ReverseMap();
            CreateMap<ProductoDTO, Producto>()
           .ForMember(dest => dest.IdProducto, orig => orig.MapFrom(o => o.IdProducto))
           .ForMember(dest => dest.Nombre, orig => orig.MapFrom(o => o.Nombre))
           .ForMember(dest => dest.Descripcion, orig => orig.MapFrom(o => o.Descripcion))
           .ForMember(dest => dest.IdCategoria, orig => orig.MapFrom(o => o.IdCategoria))
           .ForMember(dest => dest.Precio, orig => orig.MapFrom(o => o.Precio))
           .ForMember(dest => dest.Volumen, orig => orig.MapFrom(o => o.Volumen))
           .ForMember(dest => dest.Marca, orig => orig.MapFrom(o => o.Marca))
           .ForMember(dest => dest.IdCategoriaNavigation, orig => orig.MapFrom(o => o.IdCategoriaNavigation))
           .ForMember(dest => dest.FacturaProducto, orig => orig.MapFrom(o => o.FacturaProducto));
        }
    }
}
