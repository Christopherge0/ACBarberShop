using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record UsuarioDTO
    {
        [Display(Name = "Identificador del Usuario")]
        public int IdUsuario { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        public string? Telefono { get; set; }
        [Display(Name = "Correo Electronico")]
        public string? CorreoElectronico { get; set; }
        [Display(Name = "Dirección Exacta")]
        public int? IdDireccion { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateOnly? FechaNacimiento { get; set; }
        [Display(Name = "Contraseña")]
        public string? Contrasenia { get; set; }
        [Display(Name = "Rol")]
        public int? IdRol { get; set; }
        [Display(Name = "Sucursal")]
        public int? IdSucursal { get; set; }

        public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

        public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();
        [Display(Name = "Dirección Exacta")]
        public virtual Direccion? IdDireccionNavigation { get; set; }
        [Display(Name = "Rol")]
        public virtual Rol? IdRolNavigation { get; set; }
        [Display(Name = "Sucursal")]
        public virtual Sucursal? IdSucursalNavigation { get; set; }

    }
}
