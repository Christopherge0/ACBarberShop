using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record DireccionDTO
    {
        [Display(Name = "Identificador Dirección")]
        public int IdDireccion { get; set; }

        [Display(Name = "Provincia")]
        public string? Provincia { get; set; }

        [Display(Name = "Cantón")]
        public string? Canton { get; set; }

        [Display(Name = "Distrito")]
        public string? Distrito { get; set; }

        [Display(Name = "Dirección Exacta")]
        public string? DireccionExacta { get; set; }

        public virtual ICollection<Sucursal> Sucursal { get; set; } = new List<Sucursal>();

        public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
    }
}
