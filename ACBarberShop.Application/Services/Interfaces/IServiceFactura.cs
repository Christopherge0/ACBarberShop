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
        Task<ICollection<FacturaDTO>> FindByIdUsuarioSucursalAsync(int id);
        Task<ICollection<FacturaDTO>> ListAsyncFactura(int idSucursal);
        Task<int> AddAsync(FacturaDTO dto);
        Task UpdateAsync(int id, FacturaDTO dto);
        Task<int> GetNextNumberOrden();
        Task<ICollection<EstadoFacturaDTO>> ListEstadoAsync();
        Task<IEnumerable<FacturaDTO>> FindBySucursalIdAsync(int sucursalId);
        Task<ICollection<FacturaDTO>> FindByClienteIdAsync(int clienteId);
    }
}
