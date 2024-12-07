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
     public class ServiceCategoria: IServiceCategoria
    {
        private readonly IRepositoryCategoria _repository;
        private readonly IMapper _mapper;

        public ServiceCategoria(IRepositoryCategoria repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoriaDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<CategoriaDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<CategoriaDTO>> ListAsync()
        {
            //Obtener datos del repositorio
            var list = await _repository.ListAsync();
            // Map List<Categoria> a ICollection<BodegaDTO>
            var collection = _mapper.Map<ICollection<CategoriaDTO>>(list);
            // Return lista
            return collection;
        }
    }
}
