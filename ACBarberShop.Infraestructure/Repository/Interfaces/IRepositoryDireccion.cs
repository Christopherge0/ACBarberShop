using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryDireccion
    {
        Task<ICollection<Direccion>> ListAsync();
        Task<Direccion> FindByIdAsync(int id);
    }
}
