using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record EstadoBloqueoDTO
    {
        [Display(Name = "Identificador Estado de Bloqueo")]
        public int IdEstadBlokeo { get; set; }

        [Display(Name = "Estado")]
        public string? Estado { get; set; }

        public virtual ICollection<Horario> Horario { get; set; } = new List<Horario>();
    }
}
