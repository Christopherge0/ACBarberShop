using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACBarberShop.Infraestructure.Models;
using ACBarberShop.Application.DTOs;

namespace ACBarberShop.Application.Services.Interfaces
{
    public interface IServiceFactura
    {
        Task<ICollection<FacturaDTO>> ListAsync();
        Task<FacturaDTO> FindByIdAsync(int id);
        Task<FacturaDTO> FindByNameAsync(string name);
    }
}
