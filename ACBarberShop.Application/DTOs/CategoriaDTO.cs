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
        public int IdCategoria { get; set; }
        
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
    }
}
