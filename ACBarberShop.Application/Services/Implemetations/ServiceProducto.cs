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
    public class ServiceProducto : IServiceProducto
    {
        private readonly IRepositoryProducto _repository;
        private readonly IMapper _mapper;

        public ServiceProducto(IRepositoryProducto repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<ProductoDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<ProductoDTO>>(list);
            return collection;
        }
        public async Task<ProductoDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<ProductoDTO>(@object);
            return objectMapped;
        }

        public Task<ProductoDTO> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddAsync(ProductoDTO dto)
        {
            var objectMapped = _mapper.Map<Producto>(dto);
            return await _repository.AddAsync(objectMapped);
        }

        public async Task UpdateAsync(int id, ProductoDTO dto)
        {
            var @object = await _repository.FindByIdAsync(id);
            var entity = _mapper.Map(dto, @object!);

            await _repository.UpdateAsync(entity);
        }

        public async Task<ICollection<ProductoDTO>> ListByCategoryAsync(int categoryId)
        {
            var producto = await _repository.ListByCategoryAsync(categoryId);
            return _mapper.Map<ICollection<ProductoDTO>>(producto);
        }
    }
}
