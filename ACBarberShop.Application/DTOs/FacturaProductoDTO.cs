using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record FacturaProductoDTO
    {
        [Display(Name = "Identificador Factura Producto")]
        public int IdFacturaProducto { get; set; }

        [Display(Name = "Identificador Factura")]
        public int? IdFactura { get; set; }

        [Display(Name = "Identificador Producto")]
        public int? IdProducto { get; set; }

        [Display(Name = "Cantidad")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        public int? Cantidad { get; set; }

        [Display(Name = "Subtotal")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El subtotal debe ser mayor que cero.")]
        public decimal? SubTotal { get; set; }

        public virtual Factura? IdFacturaNavigation { get; set; }

        public virtual Producto? IdProductoNavigation { get; set; }
    }
}
