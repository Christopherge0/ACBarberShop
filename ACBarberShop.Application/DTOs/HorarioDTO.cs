using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record HorarioDTO
    {
        public int IdHorario { get; set; }

        public int IdSucursal { get; set; }

        public string DiaSemana { get; set; } = null!;

        public TimeOnly HoraInicio { get; set; }

        public TimeOnly HoraFin { get; set; }

        public DateOnly FechaInicio { get; set; }

        public DateOnly FechaFin { get; set; }

        public int IdEstado { get; set; }

        public virtual EstadoBloqueo IdEstadoNavigation { get; set; } = null!;

        public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    }
}
