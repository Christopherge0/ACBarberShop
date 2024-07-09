using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record SucursalDTO
    {
        [Display(Name = "Identificador")]
        public int IdSucursal { get; set; }

        [Required(ErrorMessage = "El nombre de la sucursal es requerido.")]
        public string? Nombre { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La descripción de la sucursal es requerida.")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es requerido.")]
        [Phone(ErrorMessage = "El campo Teléfono debe ser un número válido.")]
        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }

        [Display(Name = "Dirección")]

        public int? IdDireccion { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El campo Correo Electrónico es requerido.")]
        [EmailAddress(ErrorMessage = "El campo Correo Electrónico debe ser una dirección válida.")]
        public string? CorreoElectronico { get; set; }

        public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

        public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();

        public virtual ICollection<Horario> Horario { get; set; } = new List<Horario>();

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "El campo Dirección es requerido.")]
        public virtual Direccion? IdDireccionNavigation { get; set; }

        [Display(Name = "Encargado:")]
        public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();


    }
}
