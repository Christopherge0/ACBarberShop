using ACBarberShop.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.Services.Interfaces
{
    public interface IServiceFacturaServicio
    {
        Task<ICollection<FacturaServicioDTO>> ListAsync();
        Task<FacturaServicioDTO> FindByIdAsync(int id);
        Task<FacturaServicioDTO> FindByNameAsync(string name);
        Task<int> AddAsync(FacturaServicioDTO dto); //Crear 

        Task UpdateAsync(int id, FacturaServicioDTO dto); //Editar
    }
}
