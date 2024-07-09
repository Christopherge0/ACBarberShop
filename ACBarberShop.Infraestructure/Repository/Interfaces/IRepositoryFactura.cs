using ACBarberShop.Infraestructure.Models;
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
    }
}
