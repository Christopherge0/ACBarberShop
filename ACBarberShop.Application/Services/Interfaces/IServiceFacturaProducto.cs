using ACBarberShop.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.Services.Interfaces
{
    public interface IServiceFacturaProducto
    {
        Task<ICollection<FacturaProductoDTO>> ListAsync();
        Task<FacturaProductoDTO> FindByIdAsync(int id);
        Task<FacturaProductoDTO> FindByNameAsync(string name);
        Task<int> AddAsync(FacturaProductoDTO dto); //Crear 

        Task UpdateAsync(int id, FacturaProductoDTO dto); //Editar
    }
}
