using ACBarberShop.Application.DTOs;
using ACBarberShop.Application.Services.Interfaces;
using ACBarberShop.Infraestructure.Models;
using ACBarberShop.Infraestructure.Repository.Implemetations;
using ACBarberShop.Infraestructure.Repository.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public async Task<int> AddAsync(CitaDTO cita)
        {
            var @object = _mapper.Map<Cita>(cita);
            return await _repository.AddAsync(@object);
        }

        public async Task<CitaDTO> FindByAsync(int id)
        {
            var @object = await _repository.FindByAsync(id);
            var objectMapped = _mapper.Map<CitaDTO>(@object);
            return objectMapped;
        }

        public async Task<Dictionary<string, int>> GetCitasPorSucursalHoyAsync()
        {
            var citas = await _repository.GetCitasPorSucursalHoyAsync();

            return citas
                .GroupBy(c => c.IdSucursalNavigation?.Nombre ?? "Sucursal Desconocida")
                .ToDictionary(g => g.Key!, g => g.Count());
        }

        public ICollection<CitaDTO> ListFechaInvestigacionUsuario()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CitaDTO>> ListFechaInvestigacionUsuarioAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CitaDTO>> ListIdUsuarioAsync(int id)
        {
            var list = await _repository.ListIdUsuarioAsync(id);
            var collection = _mapper.Map<ICollection<CitaDTO>>(list);
            return collection;
        }
        public async Task<EstadosCitaDTO> ListCategriasAsync(int id)
        {
            var @object = await _repository.ListCategriasAsync(id);
            var objectMapped = _mapper.Map<EstadosCitaDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<CitaDTO>> ListAsyncCita(int idSucursal)
        {
            var list = await _repository.ListAsyncCita(idSucursal);
            var collection = _mapper.Map<ICollection<CitaDTO>>(list);
            return collection;
        }

        public async Task<ICollection<CitaDTO>> ListClienteSelectAsync(int idUsuario)
        {
            var list = await _repository.ListClienteSelectAsync(idUsuario);
            var collection = _mapper.Map<ICollection<CitaDTO>>(list);
            return collection;
        }

        public async Task<IEnumerable<CitaDTO>> ListFechaAsync(DateOnly fechaCita)
        {
            var @objects = await _repository.ListFechaAsync(fechaCita);
            var objectsMapped = _mapper.Map<IEnumerable<CitaDTO>>(objects);
            return objectsMapped;
        }
    }
}
