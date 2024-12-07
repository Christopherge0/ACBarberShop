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
    public class ServiceSucursal: IServiceSucursal
    {
        private readonly IRepositorySucursal _repository;
        private readonly IMapper _mapper;

        public ServiceSucursal(IRepositorySucursal repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(SucursalDTO dto, string[] selectedUsuarios)
        {
           var objectMapped = _mapper.Map<Sucursal>(dto);
            return await _repository.AddAsync(objectMapped, selectedUsuarios);
        }

        public async Task<SucursalDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<SucursalDTO>(@object);
            return objectMapped;
        }

        public Task<SucursalDTO> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SucursalDTO>> GetAllSucursalesAsync()
        {
            var sucursales = await _repository.GetAllAsync();
            return _mapper.Map<List<SucursalDTO>>(sucursales);
        }

        public async Task<ICollection<SucursalDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<SucursalDTO>>(list);
            return collection;
        }

        public async Task UpdateAsync(int id, SucursalDTO dto, string[] selectedUsuarios)
        {
           var @object = await _repository.FindByIdAsync(id);
            var entity = _mapper.Map(dto, @object!);

            await _repository.UpdateAsync(entity, selectedUsuarios);
        }
    }
}
