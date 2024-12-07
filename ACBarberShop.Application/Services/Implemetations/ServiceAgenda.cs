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
    public class ServiceAgenda: IServiceAgenda
    {
        private readonly IRepositoryAgenda repositoryAgenda;
        private readonly IMapper _mapper;

        public ServiceAgenda(IRepositoryAgenda repositoryAgenda, IMapper mapper)
        {
            this.repositoryAgenda = repositoryAgenda;
            _mapper = mapper;
        }

        public async Task<ICollection<CitaDTO>> ObtenerCitasPorSemanaAsync(int idSucursal, DateTime inicioSemana)
        {
            var citas = await repositoryAgenda.ObtenerCitasPorSemanaAsync(idSucursal, inicioSemana);
            var citasDTO = _mapper.Map<ICollection<CitaDTO>>(citas);
            return citasDTO;
        }

        public async Task<ICollection<HorarioDTO>> ObtenerHorariosPorSemanaAsync(int idSucursal, DateTime inicioSemana)
        {
            var horarios = await repositoryAgenda.ObtenerHorariosPorSemanaAsync(idSucursal, inicioSemana);
            var horariosDTO = _mapper.Map<ICollection<HorarioDTO>>(horarios);
            return horariosDTO;
        }
    }
}
