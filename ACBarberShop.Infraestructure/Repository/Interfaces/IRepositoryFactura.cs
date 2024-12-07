using ACBarberShop.Infraestructure.Models;
using ACBarberShop.Infraestructure.Repository.Implemetations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryFactura
    {
        Task<ICollection<Factura>> ListAsync();
        Task<Factura> FindByIdAsync(int id);
        Task<Factura> FindByNameAsync(string name);
        Task<ICollection<Factura>> FindByIdUsuarioSucursalAsync(int id);
        Task<ICollection<Factura>> ListAsyncFactura(int idSucursal);
        Task<int> AddAsync(Factura factura);
        Task UpdateAsync(Factura factura);
        Task<int> GetNextNumberOrden();
        Task<ICollection<EstadoFactura>> ListEstadoAsync();
        Task<IEnumerable<Factura>> FindBySucursalIdAsync(int sucursalId);
        Task<ICollection<Factura>> FindByClienteIdAsync(int clienteId);


    }
}
