using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryFacturaServicio
    {
        Task<ICollection<FacturaServicio>> ListAsync();
        Task<FacturaServicio> FindByIdAsync(int id);
        Task<int> AddAsync(FacturaServicio entity); //Crear
        Task UpdateAsync(FacturaServicio entity); //Editar
        Task DeleteAsync(int id); //Eliminar
        Task<FacturaServicio> FindByNameAsync(string name);
    }
}
