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
    public class ServiceFacturaServicio: IServiceFacturaServicio
    {
        private readonly IRepositoryFacturaServicio _repository;
        private readonly IMapper _mapper;

        public ServiceFacturaServicio(IRepositoryFacturaServicio repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(FacturaServicioDTO dto)
        {
            var objectMapped = _mapper.Map<FacturaServicio>(dto);
            return await _repository.AddAsync(objectMapped);
        }

        public async Task<FacturaServicioDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<FacturaServicioDTO>(@object);
            return objectMapped;
        }

        public Task<FacturaServicioDTO> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<FacturaServicioDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<FacturaServicioDTO>>(list);
            return collection;
        }

        public async Task UpdateAsync(int id, FacturaServicioDTO dto)
        {
            var @object = await _repository.FindByIdAsync(id);
            var entity = _mapper.Map(dto, @object!);

            await _repository.UpdateAsync(entity);
        }
    }
}
