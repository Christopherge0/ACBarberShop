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
        [Display(Name = "Identificador de Sucursal")]
        public int IdSucursal { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }

        [Display(Name = "Dirección")]
        public int? IdDireccion { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string? CorreoElectronico { get; set; }

        public virtual ICollection<Cita>? Cita { get; set; } = new List<Cita>();

        public virtual ICollection<Factura>? Factura { get; set; } = new List<Factura>();

        public virtual ICollection<Horario>? Horario { get; set; } = new List<Horario>();

        public virtual Direccion? IdDireccionNavigation { get; set; }
        public virtual ICollection<Usuario>? Usuario { get; set; } = new List<Usuario>();

    }
}
