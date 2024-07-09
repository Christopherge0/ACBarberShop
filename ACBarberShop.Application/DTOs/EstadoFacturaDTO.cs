using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record EstadoFacturaDTO
    {
        public int IdEstadoFactura { get; set; }

        public string? Descripccion { get; set; }

        public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();
    }
}
