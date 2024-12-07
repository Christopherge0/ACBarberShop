using ACBarberShop.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.Services.Interfaces
{
    public interface IServiceDireccion
    {
        Task<ICollection<DireccionDTO>> ListAsync();
        Task<DireccionDTO> FindByIdAsync(int id);
    }
}
