using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    //Usuarios
    public record RolDTO
    {
        public int IdRol { get; set; }

        public string? Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();

    }
}
