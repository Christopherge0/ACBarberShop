using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record FacturaDTO
    {
        [Display(Name = "Identificador")]
        public int IdFactura { get; set; }

        public int? IdCliente { get; set; }

        public string? Nombre { get; set; }

        public string? Telefono { get; set; }

        public string? CorreoElectronico { get; set; }

        public int? IdSucursal { get; set; }

        public decimal? Total { get; set; }
        [Display(Name = "Estado")]
        public int? IdEstado { get; set; }
        public DateOnly? Fecha { get; set; }

        public virtual ICollection<FacturaProducto> FacturaProducto { get; set; } = new List<FacturaProducto>();

        public virtual ICollection<FacturaServicio> FacturaServicio { get; set; } = new List<FacturaServicio>();

        public virtual Usuario? IdClienteNavigation { get; set; }

        public virtual EstadoFactura? IdEstadoNavigation { get; set; }

        public virtual Sucursal? IdSucursalNavigation { get; set; }

    }
}
