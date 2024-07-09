using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record ServicioDTO
    {
        public int IdSevicio { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public decimal? Tarifa { get; set; }

        public int? TiempoServicio { get; set; }

        public int? IdProducto { get; set; }

        public string? AreaEnfoque { get; set; }

        public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

        public virtual ICollection<FacturaServicio> FacturaServicio { get; set; } = new List<FacturaServicio>();
    }
}
