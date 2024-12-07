using ACBarberShop.Application.DTOs;
using ACBarberShop.Application.Services.Interfaces;
using ACBarberShop.Infraestructure.Repository.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.Services.Implemetations
{
    public class ServiceFacturaGraficos : IServiceFacturaGraficos
    {
        private readonly IRepositoryFacturaGraficos _repository;
        private readonly IMapper _mapper;

        public ServiceFacturaGraficos(IRepositoryFacturaGraficos repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ServicioVentaDTO>> GetTopServiciosMasVendidosAsync(int topN)
        {
            var topServiciosEntities = await _repository.GetTopServiciosMasVendidosAsync(topN);
            var topServiciosDTOs = _mapper.Map<List<ServicioVentaDTO>>(topServiciosEntities);

            return topServiciosDTOs;
        }
    }
}
