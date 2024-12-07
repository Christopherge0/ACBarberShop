using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public record HorarioDTO
    {
        [Display(Name = "Identificador Horario")]
        public int IdHorario { get; set; }

        [Display(Name = "Sucursal")]
        [Required(ErrorMessage = "La sucursal es obligatoria.")]
        public int IdSucursal { get; set; }

        [Display(Name = "Día")]
        [Required(ErrorMessage = "El día de la semana es obligatorio.")]
       // [StringLength(10, ErrorMessage = "El día de la semana no puede exceder los 10 caracteres.")]
        public string DiaSemana { get; set; } = null!;

        [Display(Name = "Hora de Inicio")]
        [Required(ErrorMessage = "La hora de inicio es obligatoria.")]
        public TimeOnly HoraInicio { get; set; }

        [Display(Name = "Hora de Fin")]
        [Required(ErrorMessage = "La hora de fin es obligatoria.")]
      //  [CustomValidation(typeof(Horario), nameof(ValidateHoraFin))]
        public TimeOnly HoraFin { get; set; }

        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateOnly FechaInicio { get; set; }

        [Display(Name = "Fecha de Fin")]
        [Required(ErrorMessage = "La fecha de fin es obligatoria.")]
     //   [CustomValidation(typeof(Horario), nameof(ValidateFechaFin))]
        public DateOnly FechaFin { get; set; }

        [Display(Name = "Estado del Bloqueo")]
        [Required(ErrorMessage = "El estado del bloqueo es obligatorio.")]
        public int IdEstado { get; set; }

        public virtual EstadoBloqueo? IdEstadoNavigation { get; set; } = null!;

        public virtual Sucursal? IdSucursalNavigation { get; set; } = null!;


        // Métodos de validación personalizada
      

    }
}
