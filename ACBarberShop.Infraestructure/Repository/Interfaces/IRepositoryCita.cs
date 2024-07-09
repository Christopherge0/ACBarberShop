using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryCita
    {

        Task<ICollection<Cita>> ListIdUsuarioAsync(int id);
        Task<Cita> FindByAsync(int id);

    }
}
