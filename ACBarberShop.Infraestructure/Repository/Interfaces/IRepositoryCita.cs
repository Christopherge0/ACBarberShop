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
        ICollection<Cita> ListFechaInvestigacionUsuario();
        Task<List<Cita>> GetCitasPorSucursalHoyAsync();
        Task<int> AddAsync(Cita cita);
        Task<EstadosCita> ListCategriasAsync(int id);
        Task<ICollection<Cita>> ListAsyncCita(int idSucursal);
        Task <ICollection<Cita>> ListClienteSelectAsync(int idUsuario);
        Task <IEnumerable<Cita>> ListFechaAsync(DateOnly fechaCita);



    }
}
