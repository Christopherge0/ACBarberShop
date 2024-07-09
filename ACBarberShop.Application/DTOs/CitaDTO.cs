using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record CitaDTO
    {
        [Display(Name = "Identificador")]
        public int IdCita { get; set; }

        public int IdCliente { get; set; }

        public int IdSucursal { get; set; }

        public int IdServicio { get; set; }

        public int IdEstado { get; set; }
        [Display(Name = "Fecha y hora")]
        public DateTime FechaHora { get; set; }
        [Display(Name = "Reprogramada")]
        public DateTime? FechaHoraReprogramada { get; set; }
        [Display(Name = "Fecha de creación")]
        public DateTime FechaCreacion { get; set; }

        public virtual Usuario IdClienteNavigation { get; set; } = null!;

        public virtual EstadosCita IdEstadoNavigation { get; set; } = null!;

        public virtual Servicio IdServicioNavigation { get; set; } = null!;

        public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
    }
}
