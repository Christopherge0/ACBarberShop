using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record FacturaDTO
    {
        [Display(Name = "Identificador de Factura")]
        public int IdFactura { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "El cliente es obligatorio.")]
        public int? IdCliente { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string? Nombre { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        [StringLength(15, ErrorMessage = "El teléfono no puede exceder los 15 caracteres.")]
        public string? Telefono { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [StringLength(100, ErrorMessage = "El correo electrónico no puede exceder los 100 caracteres.")]
        public string? CorreoElectronico { get; set; }

        [Display(Name = "Sucursal")]
        [Required(ErrorMessage = "La sucursal es obligatoria.")]
        public int? IdSucursal { get; set; }

        [Display(Name = "Total")]
        [Required(ErrorMessage = "El total es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor que cero.")]
        public decimal? Total { get; set; }

        [Display(Name = "Estado")]
       // [Required(ErrorMessage = "El estado es obligatorio.")]
        public int? IdEstado { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateOnly? Fecha { get; set; }


        public virtual ICollection<FacturaProducto>? FacturaProducto { get; set; } = new List<FacturaProducto>();

        public virtual ICollection<FacturaServicio>? FacturaServicio { get; set; } = new List<FacturaServicio>();

        public virtual Usuario? IdClienteNavigation { get; set; }

        public virtual EstadoFactura? IdEstadoNavigation { get; set; }

        public virtual Sucursal? IdSucursalNavigation { get; set; }

    }
}
