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
       
        [Required(ErrorMessage = "El nombre del producto es requerido.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre del producto debe tener entre 3 y 100 caracteres.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La descripción del producto es requerida.")]
        public string? Descripcion { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "La categoría del producto es requerida.")]
        public int? IdCategoria { get; set; }

        [Required(ErrorMessage = "El precio del producto es requerido.")]
        [Range(1, 1000000, ErrorMessage = "El precio debe estar entre ₡1 y ₡1,000,000.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El precio debe ser un número válido.")]
        public decimal? Precio { get; set; }

        [Required(ErrorMessage = "El volumen del producto es requerido.")]
       
        public string? Volumen { get; set; }

        [Required(ErrorMessage = "La marca del producto es requerida.")]
        public string? Marca { get; set; }

        public virtual ICollection<FacturaProducto> FacturaProducto { get; set; } = new List<FacturaProducto>();
        
        public virtual Categoria? IdCategoriaNavigation { get; set; }
    }
}
