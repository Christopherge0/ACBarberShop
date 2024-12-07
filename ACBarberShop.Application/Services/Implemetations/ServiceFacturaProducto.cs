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
    public class ServiceFacturaProducto: IServiceFacturaProducto
    {
        private readonly IRepositoryFacturaProducto _repository;
        private readonly IMapper _mapper;

        public ServiceFacturaProducto(IRepositoryFacturaProducto repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(FacturaProductoDTO dto)
        {
            var objectMapped = _mapper.Map<FacturaProducto>(dto);
            return await _repository.AddAsync(objectMapped);
        }

        public async Task<FacturaProductoDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<FacturaProductoDTO>(@object);
            return objectMapped;
        }

        public Task<FacturaProductoDTO> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<FacturaProductoDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<FacturaProductoDTO>>(list);
            return collection;
        }

        public async Task UpdateAsync(int id, FacturaProductoDTO dto)
        {
            var @object = await _repository.FindByIdAsync(id);
            var entity = _mapper.Map(dto, @object!);

            await _repository.UpdateAsync(entity);
        }
    }
}
