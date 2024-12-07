using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record CitaDTO
    {
        [Display(Name = "Identificador")]
        public int IdCita { get; set; }

        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }

        [Display(Name = "Sucursal")]
        public int IdSucursal { get; set; }

        [Display(Name = "Servicio")]
        public int IdServicio { get; set; }

        [Display(Name = "Estado")]
        public int IdEstado { get; set; }

        [Display(Name = "Fecha Reserva")]
        [Required(ErrorMessage = "La fecha de reserva es obligatoria.")]
        public DateOnly FechaCita { get; set; }

        [Display(Name = "Hora de inicio")]
        [Required(ErrorMessage = "La hora de inicio es obligatoria.")]
        public TimeOnly HoraInicio { get; set; }

        [Display(Name = "Hora de fin")]
        [Required(ErrorMessage = "La hora de fin es obligatoria.")]
       // [CustomValidation(typeof(TuModelo), nameof(ValidateHoraFin))]
        public TimeOnly HoraFin { get; set; }

        [Display(Name = "Reprogramada")]
        public DateOnly? FechaReprogramada { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateOnly? FechaCreacion { get; set; }

        [Display(Name = "¿Tiene alguna alergia a productos capilares o de cuidado personal?")]
        [StringLength(250, ErrorMessage = "La respuesta no puede exceder los 250 caracteres.")]
        public string? Pregunta1 { get; set; }

        [Display(Name = "¿Tiene alguna preferencia en cuanto al estilo o corte que desea?")]
        [StringLength(250, ErrorMessage = "La respuesta no puede exceder los 250 caracteres.")]
        public string? Pregunta2 { get; set; }

        [Display(Name = "¿Hay algún problema o condición del cuero cabelludo que debamos conocer?")]
        [StringLength(250, ErrorMessage = "La respuesta no puede exceder los 250 caracteres.")]
        public string? Pregunta3 { get; set; }

        public virtual Usuario? IdClienteNavigation { get; set; } = null!;

        public virtual EstadosCita? IdEstadoNavigation { get; set; } = null!;

        public virtual Servicio? IdServicioNavigation { get; set; } = null!;

        public virtual Sucursal? IdSucursalNavigation { get; set; } = null!;
    }
}
