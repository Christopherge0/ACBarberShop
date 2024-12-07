using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryAgenda
    {
        Task<ICollection<Horario>> ObtenerHorariosPorSemanaAsync(int idSucursal, DateTime inicioSemana);
        Task<ICollection<Cita>> ObtenerCitasPorSemanaAsync(int idSucursal, DateTime inicioSemana);
    }
}
