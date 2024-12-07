using ACBarberShop.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.Services.Interfaces
{
    public interface IServiceSucursal
    {
        Task<ICollection<SucursalDTO>> ListAsync();
        Task<SucursalDTO> FindByIdAsync(int id);
        Task<SucursalDTO> FindByNameAsync(string name);
        Task<int> AddAsync(SucursalDTO dto, string[] selectedUsuarios); //Crear 

        Task UpdateAsync(int id, SucursalDTO dto, string[] selectedUsuarios); //Editar

        Task<List<SucursalDTO>> GetAllSucursalesAsync();
    }
}
