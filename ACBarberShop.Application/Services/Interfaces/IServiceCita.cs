using ACBarberShop.Application.DTOs;
using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.Services.Interfaces
{
    public interface IServiceCita
    {
        Task<CitaDTO> FindByAsync(int id);

        Task<ICollection<CitaDTO>> ListIdUsuarioAsync(int id);
        ICollection<CitaDTO> ListFechaInvestigacionUsuario();
        Task<Dictionary<string, int>> GetCitasPorSucursalHoyAsync();
        Task<int> AddAsync(CitaDTO cita);
        Task<EstadosCitaDTO> ListCategriasAsync(int id);
        Task<ICollection<CitaDTO>> ListAsyncCita(int idSucursal);
        Task<ICollection<CitaDTO>> ListClienteSelectAsync(int idUsuario);
        Task<IEnumerable<CitaDTO>> ListFechaAsync(DateOnly fechaCita);
    }
}
