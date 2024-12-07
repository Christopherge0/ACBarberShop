using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryProducto
    {
        Task<ICollection<Producto>> ListAsync();
        Task<Producto> FindByIdAsync(int id);
        Task<int> AddAsync(Producto entity); //Crear
        Task UpdateAsync(Producto entity); //Editar
        Task DeleteAsync(int id); //Eliminar
        Task<Producto> FindByNameAsync(string name);
        Task<ICollection<Producto>> ListByCategoryAsync(int categoryId);
    }
}
