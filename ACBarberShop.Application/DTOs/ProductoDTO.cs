using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record ProductoDTO
    {
        [Display(Name = "Identificador")]
        public int IdProducto { get; set; }

        [Display(Name = "Nombre")]

        public string? Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Display(Name = "Categoría")]
        public int? IdCategoria { get; set; }

        [Display(Name = "Precio")]
        public decimal? Precio { get; set; }

        [Display(Name = "Volumen")]
        public string? Volumen { get; set; }

        [Display(Name = "Marca")]
        public string? Marca { get; set; }

        [Display(Name = "Cantidad")]
        public int? Cantidad { get; set; }

        public virtual ICollection<FacturaProducto> FacturaProducto { get; set; } = new List<FacturaProducto>();

        public virtual Categoria? IdCategoriaNavigation { get; set; }
    }
}
