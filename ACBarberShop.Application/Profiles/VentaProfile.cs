using ACBarberShop.Application.DTOs;
using ACBarberShop.Infraestructure.Repository.Implemetations;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.Profiles
{
    public class VentaProfile : Profile
    {
        public VentaProfile()
        {
            CreateMap<ServicioVentaEntity, ServicioVentaDTO>()
                .ForMember(dest => dest.NombreServicio, opt => opt.MapFrom(src => src.NombreServicio))
                .ForMember(dest => dest.TotalCantidad, opt => opt.MapFrom(src => src.TotalCantidad));
        }
    }

}
