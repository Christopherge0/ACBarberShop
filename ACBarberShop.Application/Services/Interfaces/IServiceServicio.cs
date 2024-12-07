using ACBarberShop.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.Services.Interfaces
{
    public interface IServiceServicio
    {
        Task<ICollection<ServicioDTO>> ListAsync();
        Task<ServicioDTO> FindByIdAsync(int id);
        Task<ServicioDTO> FindByNameAsync(string name);
        Task<int> AddAsync(ServicioDTO dto); //Crear 

        Task UpdateAsync(int id, ServicioDTO dto); //Editar
        Task<ICollection<ServicioDTO>> ListByNameAsync(string name);
    }
}
