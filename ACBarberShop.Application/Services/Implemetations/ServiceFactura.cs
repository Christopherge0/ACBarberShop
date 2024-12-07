using ACBarberShop.Application.DTOs;
using ACBarberShop.Application.Services.Interfaces;
using ACBarberShop.Infraestructure.Models;
using ACBarberShop.Infraestructure.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.Services.Implemetations
{
    public class ServiceFactura : IServiceFactura
    {
        private readonly IRepositoryFactura _repository;
        private readonly IMapper _mapper;

        public ServiceFactura(IRepositoryFactura repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(FacturaDTO dto)
        {
            var @object = _mapper.Map<Factura>(dto);
            return await _repository.AddAsync(@object);
        }

        public async Task<FacturaDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<FacturaDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<FacturaDTO>> FindByIdUsuarioSucursalAsync(int id)
        {
            var list = await _repository.FindByIdUsuarioSucursalAsync(id);
            var collection = _mapper.Map<ICollection<FacturaDTO>>(list);
            return collection;
        }

        public Task<FacturaDTO> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetNextNumberOrden()
        {
            int nextReceipt = await _repository.GetNextNumberOrden();
            return nextReceipt;
        }

        public async Task<ICollection<FacturaDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<FacturaDTO>>(list);
            return collection;
        }

        public async Task<ICollection<FacturaDTO>> ListAsyncFactura(int idSucursal)
        {
            var list = await _repository.ListAsyncFactura(idSucursal);
            var collection = _mapper.Map<ICollection<FacturaDTO>>(list);
            return collection;
        }

        public async Task UpdateAsync(int id, FacturaDTO dto)
        {
            var entity = _mapper.Map<Factura>(dto);

            await _repository.UpdateAsync(entity);
        }

        public async Task<ICollection<EstadoFacturaDTO>> ListEstadoAsync()
        {
            var list = await _repository.ListEstadoAsync();
            var collection = _mapper.Map<ICollection<EstadoFacturaDTO>>(list);
            return collection;
        }

        public async Task<IEnumerable<FacturaDTO>> FindBySucursalIdAsync(int sucursalId)
        {
            var list = await _repository.ListAsyncFactura(sucursalId);
            var collection = _mapper.Map<ICollection<FacturaDTO>>(list);
            return collection;
        }

        public async Task<ICollection<FacturaDTO>> FindByClienteIdAsync(int clienteId)
        {
            var list = await _repository.FindByClienteIdAsync(clienteId);
            var collection = _mapper.Map<ICollection<FacturaDTO>>(list);
            return collection;
        }
    }
}
