using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record ServicioDTO
    {
        [Display(Name = "Identificador del Servicio")]
        public int IdSevicio { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Display(Name = "Tarifa")]
        public decimal? Tarifa { get; set; }

        [Display(Name = "Tiempo de Servicio (minutos)")]
        public int? TiempoServicio { get; set; }

        [Display(Name = "Producto Asociado")]
        public int? IdProducto { get; set; }

        [Display(Name = "Área de Enfoque")]
        public string? AreaEnfoque { get; set; }

        public virtual ICollection<Cita>? Cita { get; set; } = new List<Cita>();

        public virtual ICollection<FacturaServicio>? FacturaServicio { get; set; } = new List<FacturaServicio>();
    }
}
