using ACBarberShop.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.Services.Interfaces
{
    public interface IServiceAgenda
    {
        Task<ICollection<HorarioDTO>> ObtenerHorariosPorSemanaAsync(int idSucursal, DateTime inicioSemana);
        Task<ICollection<CitaDTO>> ObtenerCitasPorSemanaAsync(int idSucursal, DateTime inicioSemana);
    }
}
