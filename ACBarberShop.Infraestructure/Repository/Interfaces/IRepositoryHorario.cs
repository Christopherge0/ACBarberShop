using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryHorario
    {
        Task<ICollection<Horario>> ListAsync();
        Task<Horario> FindByIdAsync(int id);
        Task<int> AddAperturaAsync(Horario entity); //Crear Apertura
        Task<int> AddBlokeoAsync(Horario entity);//Crear blokeo
        Task UpdateAsync(Horario entity); //Editar
        Task DeleteAsync(int id); //Eliminar
        Task<Horario> FindByNameAsync(string name);
        Task<IEnumerable<Horario>> GetHorariosPorFechaYSucursal(DateOnly fechaInicio, DateOnly FechaFin, int? idSucursal);
        Task<ICollection<Horario>> ListAsyncBySucursal(int idSucursal);
    }
}