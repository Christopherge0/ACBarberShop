using ACBarberShop.Application.DTOs;
using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.Services.Interfaces
{
    public interface IServiceProducto
    {
        Task<ICollection<ProductoDTO>> ListAsync();
        Task<ProductoDTO> FindByIdAsync(int id);
        Task<ProductoDTO> FindByNameAsync(string name);
        Task<int> AddAsync(ProductoDTO dto); //Crear 

        Task UpdateAsync(int id, ProductoDTO dto); //Editar
        Task<ICollection<ProductoDTO>> ListByCategoryAsync(int categoryId);
    }
}
