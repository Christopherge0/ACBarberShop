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
    public class ServiceDireccion: IServiceDireccion
    {
        private readonly IRepositoryDireccion _repository;
        private readonly IMapper _mapper;

        public ServiceDireccion(IRepositoryDireccion repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DireccionDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<DireccionDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<DireccionDTO>> ListAsync()
        {
            //Obtener datos del repositorio
            var list = await _repository.ListAsync();
            // Map List<Categoria> a ICollection<BodegaDTO>
            var collection = _mapper.Map<ICollection<DireccionDTO>>(list);
            // Return lista
            return collection;
        }
    }
}
