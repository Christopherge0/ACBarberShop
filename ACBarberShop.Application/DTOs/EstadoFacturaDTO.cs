using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record EstadoFacturaDTO
    {
        [Display(Name = "Identificador Estado Factura")]
        public int IdEstadoFactura { get; set; }

        [Display(Name = "Descripción")]
        public string? Descripccion { get; set; }

        public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();
    }
}
