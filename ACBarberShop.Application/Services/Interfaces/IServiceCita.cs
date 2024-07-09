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



    }
}
