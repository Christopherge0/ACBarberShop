using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    //Usuarios
    public record RolDTO
    {
        [Display(Name = "Identificador del Rol")]
        public int IdRol { get; set; }

        [Display(Name = "Descripción del Rol")]
        public string? Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();

    }
}
