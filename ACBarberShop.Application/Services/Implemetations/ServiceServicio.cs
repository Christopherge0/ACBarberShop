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
    public class ServiceServicio : IServiceServicio
    {
        private readonly IRepositoryServicio _repository;
        private readonly IMapper _mapper;

        public ServiceServicio(IRepositoryServicio repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ServicioDTO dto)
        {
            var objectMapped = _mapper.Map<Servicio>(dto);
            return await _repository.AddAsync(objectMapped);
        }

        public async Task<ServicioDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<ServicioDTO>(@object);
            return objectMapped;
        }

        public Task<ServicioDTO> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ServicioDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<ServicioDTO>>(list);
            return collection;
        }

        public async Task<ICollection<ServicioDTO>> ListByNameAsync(string name)
        {
            var services = await _repository.ListByNameAsync(name);
            return _mapper.Map<ICollection<ServicioDTO>>(services);
        }

        public async Task UpdateAsync(int id, ServicioDTO dto)
        {
            var @object = await _repository.FindByIdAsync(id);
            var entity = _mapper.Map(dto, @object!);

            await _repository.UpdateAsync(entity);
        }
    }
}
