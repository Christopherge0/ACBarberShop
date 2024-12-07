using ACBarberShop.Application.DTOs;
using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.Services.Interfaces
{
    public interface IServiceHorario
    {
        Task<ICollection<HorarioDTO>> ListAsync();
        Task<HorarioDTO> FindByIdAsync(int id);
        Task<int> AddAperturaAsync(HorarioDTO dto); //Crear Apertura
        Task<int> AddBlokeoAsync(HorarioDTO dto);//Crear blokeo
        Task UpdateAsync(HorarioDTO entity); //Editar
        Task DeleteAsync(int id); //Eliminar
        Task<HorarioDTO> FindByNameAsync(string name);
        Task<ICollection<HorarioDTO>> ListAsyncBySucursal(int idSucursal);
    }
}
