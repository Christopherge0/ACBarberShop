using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record FacturaProductoDTO
    {
        public int IdFacturaProducto { get; set; }

        public int? IdFactura { get; set; }

        public int? IdProducto { get; set; }

        public int? Cantidad { get; set; }

        public decimal? SubTotal { get; set; }

        public virtual Factura? IdFacturaNavigation { get; set; }

        public virtual Producto? IdProductoNavigation { get; set; }
    }
}
