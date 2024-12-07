using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Infraestructure.Repository.Interfaces
{
    public interface IRepositorySucursal
    {
        Task<ICollection<Sucursal>> ListAsync();
        Task<Sucursal> FindByIdAsync(int id);
        Task<int> AddAsync(Sucursal entity, string[] selectedUsuarios); //Crear
        Task UpdateAsync(Sucursal entity, string[] selectedUsuarios); //Editar
        Task DeleteAsync(int id); //Eliminar
        Task<Sucursal> FindByNameAsync(string name);
        Task<List<Sucursal>> GetAllAsync();
    }
}
