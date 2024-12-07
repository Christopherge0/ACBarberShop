using ACBarberShop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACBarberShop.Application.DTOs
{
    public  record EstadosCitaDTO
    {
        [Display(Name = "Identificador Estado Cita")]
        public int IdEstadoCita { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; } = null!;

        public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
    }
}
