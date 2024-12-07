using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public  record FacturaServicioDTO
    {
        [Display(Name = "Identificador de Factura Servicio")]
        public int IdFacturaServicio { get; set; }

        [Display(Name = "Identificador de Factura")]
        public int? IdFactura { get; set; }

        [Display(Name = "Identificador Servicio")]
        public int? IdServicio { get; set; }

        [Display(Name = "Subtotal")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El subtotal debe ser mayor que cero.")]
        public decimal? SubTotal { get; set; }

        [Display(Name = "Cantidad")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        public int? Cantidad { get; set; }
        public virtual Factura? IdFacturaNavigation { get; set; }

        public virtual Servicio? IdServicioNavigation { get; set; }
    }

}

