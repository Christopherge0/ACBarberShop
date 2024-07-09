using ACBarberShop.Application.DTOs;
using ACBarberShop.Application.Services.Interfaces;
using ACBarberShop.Infraestructure.Models;
using ACBarberShop.Infraestructure.Repository.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.Services.Implemetations
{
    public class ServiceCita : IServiceCita
    {
        private readonly IRepositoryCita _repository;
        private readonly IMapper _mapper;

        public ServiceCita(IRepositoryCita repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CitaDTO> FindByAsync(int id)
        {
            var @object = await _repository.FindByAsync(id);
            var objectMapped = _mapper.Map<CitaDTO>(@object);
            return objectMapped; 
        }

        public async Task<ICollection<CitaDTO>> ListIdUsuarioAsync(int id)
        {
            var list = await _repository.ListIdUsuarioAsync(id);
            var collection = _mapper.Map<ICollection<CitaDTO>>(list);
            return collection;
        }
    }
}
