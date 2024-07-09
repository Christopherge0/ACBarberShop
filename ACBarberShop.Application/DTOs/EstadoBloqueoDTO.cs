using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record EstadoBloqueoDTO
    {
        public int IdEstadBlokeo { get; set; }

        public string? Estado { get; set; }

        public virtual ICollection<Horario> Horario { get; set; } = new List<Horario>();
    }
}
