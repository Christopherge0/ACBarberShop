using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record CategoriaDTO
    {
        [Display(Name = "Identificador Categoría")]
        public int IdCategoria { get; set; }

        [Display(Name = "Nombre de la Categoría")]
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
    }
}
