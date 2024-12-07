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
    public class ServiceHorario : IServiceHorario
    {
        private readonly IRepositoryHorario _repository;
        private readonly IMapper _mapper;

        public ServiceHorario(IRepositoryHorario repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAperturaAsync(HorarioDTO dto)
        {
            var objectMapped = _mapper.Map<Horario>(dto);
            return await _repository.AddAperturaAsync(objectMapped);
        }

        public async Task<int> AddBlokeoAsync(HorarioDTO dto)
        {
            var objectMapped = _mapper.Map<Horario>(dto);
            return await _repository.AddBlokeoAsync(objectMapped);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<HorarioDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<HorarioDTO>(@object);
            return objectMapped;
        }

        public Task<HorarioDTO> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

     /*   public Task<IEnumerable<HorarioDTO>> GetHorariosPorFechaYSucursal(DateOnly fechaInicio, DateOnly FechaFin, int? idSucursal)
        {
            var horariosExistentes = await _repository.GetHorariosPorFechaYSucursal(horarioDTO.Fecha, horarioDTO.IdSucursal);

            foreach (var horario in horariosExistentes)
            {
                if ((horarioDTO.HoraInicio < horario.HoraFin && horarioDTO.HoraFin > horario.HoraInicio) ||
                    (horarioDTO.HoraInicio == horario.HoraInicio && horarioDTO.HoraFin == horario.HoraFin))
                {
                    return false; // Existe superposición
                }
            }
        }*/

        public async Task<ICollection<HorarioDTO>> ListAsync()
        {
            var list = await _repository.ListAsync();
            var collection = _mapper.Map<ICollection<HorarioDTO>>(list);
            return collection;
        }

        public async Task<ICollection<HorarioDTO>> ListAsyncBySucursal(int idSucursal)
        {
             var horarios = await _repository.ListAsyncBySucursal(idSucursal);
              return _mapper.Map<ICollection<HorarioDTO>>(horarios);
            

        }

        public Task UpdateAsync(HorarioDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}