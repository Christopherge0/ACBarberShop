using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Infraestructure.Repository.Interfaces
{
     public interface IRepositoryFacturaProducto
    {
        Task<ICollection<FacturaProducto>> ListAsync();
        Task<FacturaProducto> FindByIdAsync(int id);
        Task<int> AddAsync(FacturaProducto entity); //Crear
        Task UpdateAsync(FacturaProducto entity); //Editar
        Task DeleteAsync(int id); //Eliminar
        Task<FacturaProducto> FindByNameAsync(string name);
    }
}
