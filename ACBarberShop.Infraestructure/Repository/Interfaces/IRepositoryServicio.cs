using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryServicio
    {
        Task<ICollection<Servicio>> ListAsync();
        Task<Servicio> FindByIdAsync(int id);
        Task<int> AddAsync(Servicio entity); //Crear
        Task UpdateAsync(Servicio entity); //Editar
        Task DeleteAsync(int id); //Eliminar
        Task<Servicio> FindByNameAsync(string name);
        Task<ICollection<Servicio>> ListByNameAsync(string name);
    }
}
